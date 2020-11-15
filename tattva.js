/*https://github.com/mourner/suncalc */

window.Import(window.URL+'suncalc.js')

class Tattva{
  

constructor(idTattva){
    const DOSHORAS=2*60*60*1000;
    const TIEMPOTATTVA=DOSHORAS/5;

    
    
    this.Nombre=Tattva.Names[idTattva];
    this.Icono=this.Nombre+".jpg";
    this.TiempoDominante=Tattva.TiemposDominantes[idTattva];
    this.IdTattva=idTattva;
    this.IdSiguiente=(idTattva++)%Tattva.Total;
    this.Siguiente=TIEMPOTATTVA;
}

static TiemposDominantes=["Tiempo_Akasha","Tiempo_Vayu","Tiempo_Tejas","Tiempo_Apas","Tiempo_Prithivi"];
static Names=["Akasha","Vayu","Tejas","Apas","Prithivi"];
static Total=Tattva.Names.length;

static GetTattvaActual(lat,lon){
  return Tattva.GetTattva(lat,lon,new Date());

}
static GetTattva(lat,lon,date){
    const DOSHORAS=2*60*60*1000;
    const TIEMPOTATTVA=DOSHORAS/5;

     //calculo la hora
    //resto a la que tiene ahora
    var sunrise=SunCalc.getTimes(date,lat,lon).sunrise;
    //cada dos horas vuelve a ser el mismo tattw
    //al amanecer empieza el ciclo
    var diferencia=date-sunrise;//milisegundos
    var limpio=diferencia%DOSHORAS;
    var tattvaActual=limpio/TIEMPOTATTVA;
    var siguienteTattva=limpio%TIEMPOTATTVA;
    var tattva=new Tattva(tattvaActual);
    tattva.Siguiente=siguienteTattva;
    console.log("Tattva");
    console.log(tattva);

    return tattva;



}



}