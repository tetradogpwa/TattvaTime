window.Import = (url) => {

    var scriptNode = document.createElement("script");
    scriptNode.setAttribute("language", "JavaScript");
    scriptNode.setAttribute("type", "text/JavaScript");
    scriptNode.setAttribute("src", url);
    if (!window._MapImportScript)
        window._MapImportScript = new Map();
    //source:http://www.forosdelweb.com/f13/importar-archivo-js-dentro-javascript-387358/
    if (!window._MapImportScript.has(url)) {
        document.write(scriptNode.outerHTML);
        window._MapImportScript.set(url, url);
    }
};

window.URL="https://tetradogpwa.github.io/TattvaTime/";

window.Import(window.URL+'tattva.js');




var lat;
var lon;
var actualTattva;
var dicBueno={};
var dicMalo={};
var files=["ESP"];
var idiomaActual=0;




window.onload=()=>{
const BUENO=1;
const MALO=2;  

var campos;

var file;
var line;
var promises=[];

for(var i=0;i<Tattva.Total;i++)
{
    dicBueno[i]={};
    dicMalo[i]={};
}

for(var i=0;i<files.length;i++){
    
  promises.push(  readFile('Lang/'+files[i]).then((file)=>{
        console.log(files[i]);
        file=file.split('/n');

      for(var tattvaAPoner=0;tattvaAPoner<file.length&&tattvaAPoner<Tattva.Total;tattvaAPoner++){
            line=file[tattvaAPoner];
            campos=line.split(";");
            console.log(line);
            dicBueno[tattvaAPoner][files[i]]=campos[BUENO].split(',');
            dicMalo[tattvaAPoner][files[i]]=campos[MALO].split(',');
        
     
        }
    }).catch(console.error));

}
Promise.all(promises).then(()=>{
    CicloTatvva();
});


};

function readFile(file){
    return new Promise((resolve, reject) => { 
      var urlFile=URL+file;
      console.log(urlFile);
      fetch(urlFile).then(f=>f.text()).then(resolve);
    });
  }

function CicloTatvva(){
    UpdateGPS();
    if(actualTattva===undefined)
        {
            actualTattva=Tattva.GetTattvaActual(lat,lon);
        }
    else{
        actualTattva=new Tattva(actualTattva.IdSiguiente);     
    }
    setTimeout(CicloTatvva,actualTattva.Siguiente);
    PonTattvaActual();
}
function UpdateGPS(){
    try{
    //obtengo las inputs y lo convierto a numeros
    var latActual=parseFloat(document.getElementById('inpLat').innerText);
    var lonActual=parseFloat(document.getElementById('inpLon').innerText);

    if(lat!=latActual||lon!=lonActual){
        actualTattva=undefined;
        lat=latActual;
        lon=lonActual;
    }

    }catch{
        console.error("error al intentar hacer el parse de las coordenadas!!");
    }
}

function PonTattvaActual(){
    var bueno=dicBueno[actualTattva.IdTattva][files[idiomaActual]];
    var malo=dicMalo[actualTattva.IdTattva][files[idiomaActual]];
    var imgPath=URL+"Imagenes/"+actualTattva.Icono;
    console.log(imgPath);
    SetList('lstBueno',bueno);
    SetList('lstMalo',malo);
    document.getElementById('imgTattva').setAttribute('src',imgPath);


}
function SetList(idList,array){
    var element;
     //get list
    var list=document.getElementById(idList);
    //clear
    while( list.firstChild ){
        list.removeChild( list.firstChild );
      }
    //set elements
    for(var i=0;i<array.length;i++){ 
        //creo el elemento
        element=window.createElement('li');
        //le pongo el valor
        element.innerText=array[i];
        //lo añado a la lista
        list.appendChild(element);
    }

}