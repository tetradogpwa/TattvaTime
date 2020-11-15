var Tattva = require('./tattva');
var fs = require('fs');


var lat;
var lon;
var actualTattva;
var dicBueno={};
var dicMalo={};
var files;
var idiomaActual=0;


window.onload=()=>{

const BUENO=1;
const MALO=2;  

var campos;
var tattvaActualLang;
var lineReader = require('line-reader');

files = fs.readdirSync('/Lang/');


for(var i=0;i<files.length;i++){
    console.log(files[i]);
    dicBueno[i]={};
    dicMalo[i]={};
    tattvaActualLang=0;
    lineReader.eachLine(files[i], function(line, last) {
        campos=line.split(";");
        console.log(line);
        dicBueno[tattvaActualLang][files[i]]=campos[BUENO].split(',');
        dicMalo[tattvaActualLang][files[i]]=campos[MALO].split(',');
        tattvaActualLang++;
 
    });
}

CicloTatvva();
};
function CicloTatvva(){
    UpdateGPS();
    if(actualTattva==undefined)
        {
            actualTattva=Tattva.GetTattva(lat,lon);
        }
    else{
        actualTattva=new Tattva(actualTattva.IdSiguiente);     
    }
    setTimeout(CicloTatvva,actualTattva.Siguiente);
    PonTattvaActual();
}
function UpdateGPS(){
    //obtengo las inputs y lo convierto a numeros
    var latActual;
    var lonActual;

    if(lat!=latActual||lon!=lonActual){
        actualTattva=undefined;
    }
}
function PonTattvaActual(){
    var bueno=dicBueno[tattvaActual.IdTattva][files[idiomaActual]];
    var malo=dicMalo[tattvaActual.IdTattva][files[idiomaActual]];
    var imgPath="/Imagenes/"+tattvaActual.Icono;

}