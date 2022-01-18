export class Narudzbina{
    constructor(ime,prezime,jelo,dezert,pice){
      
        this.ime=ime;
        this.prezime=prezime;
        this.jelo=jelo;
        this.dezert=dezert;
        this.pice=pice;
    }

    crtaj(host){
       
        var tr = document.createElement("tr");
        host.appendChild(tr);

        var el;

        el = document.createElement("td");
        el.innerHTML=this.ime;
        tr.appendChild(el);
        el = document.createElement("td");
        el.innerHTML=this.prezime;
        tr.appendChild(el);
        el = document.createElement("td");
        el.innerHTML=this.jelo;
        tr.appendChild(el);
        el = document.createElement("td");
        el.innerHTML=this.dezert;
        tr.appendChild(el);
        el = document.createElement("td");
        el.innerHTML=this.pice;
        tr.appendChild(el);
        

    
    }
   
}