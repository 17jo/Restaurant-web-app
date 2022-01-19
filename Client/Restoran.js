import { Narudzbina } from "./Narudzbina.js";


export class Restoran{
    constructor(listaJela,listaPica,listaDezerta,listaRestorana)
    {
        this.listaJela=listaJela;
        this.listaDezerta=listaDezerta;
        this.listaPica=listaPica;
        this.listaRestorana=listaRestorana;
        this.kont=null;
    }

    crtaj(host){
        this.kont=document.createElement("div");
        this.kont.className="GlavniKontenjer";
        host.appendChild(this.kont);
        
        let kontForma=document.createElement("div");
        kontForma.className="Forma";
        this.kont.appendChild(kontForma);

        this.crtajFormu(kontForma);
        this.crtajPrikaz(this.kont);
    }
    
    crtajPrikaz(host){
        
        
        let kontPrikaz = document.createElement("div");
        kontPrikaz.className="Prikaz";
        host.appendChild(kontPrikaz);

        var tabela = document.createElement("table");
        tabela.className="tabela";
        kontPrikaz.appendChild(tabela);

        var tabelahead= document.createElement("thead");
        tabela.appendChild(tabelahead);

        var tr = document.createElement("tr");
        tabelahead.appendChild(tr);

        var tabelaBody = document.createElement("tbody");
        tabelaBody.className="TabelaPodaci";
        tabela.appendChild(tabelaBody);

    }

    DodavanjeKlijenta()
    {

        let ime = this.kont.querySelector(".imeclass");
        var imeTextBox = ime.value;
        
        let prezime = this.kont.querySelector(".prezimeclass");
        var prezimeTextBox = prezime.value;
        
        let brTel = this.kont.querySelector(".brojclass");
        var brTelTextBox = brTel.value;
       
       fetch("https://localhost:5001/Klijent/AddKlijent/"+imeTextBox+"/"+prezimeTextBox+"/"+brTelTextBox,
        {
            method:"POST"
        }).then( s=>
            {
                console.log(s.status);
                console.log(s);
               if (s.status ==200){ alert("Uspesno dodat klijent");}
               else
               {
                       alert("Vec postoji klijent sa tim brojem telefona");
               }
        })
    }


    ObrisiKlijenta()
    {
        let obbrTel = this.kont.querySelector(".brojclass");
        var obbrTelTextBox = obbrTel.value;

        fetch("https://localhost:5001/Klijent/DeleteKlijent/"+obbrTelTextBox,
        {
            method:"DELETE"
        }).then(s=>{
            if(s.ok){
                alert("Obrisan je klijent");
            }
            else
            {
                alert("Broj nije validan");
            }
        })

    }
    IzmeniKlijenta()
    {
        let ime = this.kont.querySelector(".imeclass");
        var imeTextBox = ime.value;
        
        let prezime = this.kont.querySelector(".prezimeclass");
        var prezimeTextBox = prezime.value;
        
        let brTel = this.kont.querySelector(".brojclass");
        var brTelTextBox = brTel.value;

        let novibrTel = this.kont.querySelector(".izmeniBrojclass");
        var novibrTelTextBox = novibrTel.value;

        fetch("https://localhost:5001/Klijent/ChangeKlijent/"+imeTextBox+"/"+prezimeTextBox+"/"+brTelTextBox+"/"+novibrTelTextBox,
        {
            method:"PUT"
        }).then(s=>{
            if(s.ok){
                alert("Klijent je izmenjen");
            }
            else
            {
                alert("Broj nije validan");
            }
        })
    }
    crtajFormu(host){

        let divDodaj = document.createElement("div");
        divDodaj.className="divDodajKlijenta";
        host.appendChild(divDodaj);
        
        var dodIme =  document.createElement("label");
        dodIme.innerHTML="Klijent podaci";
        divDodaj.appendChild(dodIme);
        
        var dod =  document.createElement("label");
        dod.innerHTML="Ime"
        divDodaj.appendChild(dod);
       
        var Naziv = document.createElement("input");
        Naziv.className = "imeclass";
        Naziv.type="text";
        divDodaj.appendChild(Naziv);
     
        
        dod =  document.createElement("label");
        dod.innerHTML="Prezime";
        divDodaj.appendChild(dod);
        
        var Naziv = document.createElement("input");
        Naziv.type="text";
        Naziv.className = "prezimeclass";
        divDodaj.appendChild(Naziv);
    

        var dodBroj =  document.createElement("label");
        dodBroj.innerHTML="Broj tel";
        divDodaj.appendChild(dodBroj);
        
        var brojTelefona1 = document.createElement("input");
        brojTelefona1.type="number";
        brojTelefona1.className="brojclass";
       divDodaj.appendChild(brojTelefona1);

        let DodajKlijenta = document.createElement("button");
        DodajKlijenta.onclick=(ev)=>this.DodavanjeKlijenta();
        DodajKlijenta.innerHTML="Dodaj Klijenta";
        divDodaj.appendChild(DodajKlijenta);
        
     
  
        let ObrisiKlijenta = document.createElement("button");
        ObrisiKlijenta.onclick=(ev)=>this.ObrisiKlijenta();
        ObrisiKlijenta.innerHTML="Obrisi Klijenta";
        divDodaj.appendChild(ObrisiKlijenta);
        
        var promBroj =  document.createElement("label");
        promBroj.innerHTML="Uneti novi br telefona";
        divDodaj.appendChild(promBroj);
        
        var brojTelefona2 = document.createElement("input");
        brojTelefona2.type="number";
        brojTelefona2.className="izmeniBrojclass";
       divDodaj.appendChild(brojTelefona2);

        let IzmeniKlijenta = document.createElement("button");
        IzmeniKlijenta.onclick=(ev)=>this.IzmeniKlijenta();
        IzmeniKlijenta.innerHTML="Izmeni Klijenta";
        divDodaj.appendChild(IzmeniKlijenta);



        let res = document.createElement("label");
        res.innerHTML="Restorani";
        host.appendChild(res);
        let rs1 = document.createElement("select");
        rs1.className="restoran1class";
        rs1.onchange = (ev)=>{this.PromenaSelekta(divNarudzbina)};
        host.appendChild(rs1);
        let op1; //opcija
        
        this.listaRestorana.forEach(j => {
            op1 = document.createElement("option");
            op1.innerHTML = j.imeRestorana;
            op1.value = j.id;
            rs1.appendChild(op1);       
        })

       let vadiIndex = this.kont.querySelector(".restoran1class");
           var ms=vadiIndex.options[vadiIndex.selectedIndex].value;
           let vadiIndex2 = this.kont.querySelector(".restoran1class");
           var ms2=vadiIndex2.options[vadiIndex2.selectedIndex].innerHTML;
       
        
       
        let kli =  document.createElement("label");
      
            kli.innerHTML="Klijent"
           host.appendChild(kli);
        var brojTelefona = document.createElement("input");
        brojTelefona.type="number";
        brojTelefona.className="konacniBrojclass";
       host.appendChild(brojTelefona);

        let opis=document.createElement("label");
         
        opis.innerHTML="Narudzbina: ";
        host.appendChild(opis);

        let divNarudzbina = document.createElement("div");
        divNarudzbina.className="Narudzbina";
        host.appendChild(divNarudzbina);
      
        let l=document.createElement("label");
        l.className="label1";
        l.innerHTML=" Jela ";
         divNarudzbina.appendChild(l);

        let se=document.createElement("select");
        se.className="jeloclass";
        divNarudzbina.appendChild(se);

      

        let op;
      
        for(var i=0;i<this.listaJela.length;i++)
        {
            if(this.listaJela[i].idRest=="Elit"==true)
            {    
                op=document.createElement("option");
                op.innerHTML=this.listaJela[i].imeJela; 
                op.value=this.listaJela[i].id;
                se.appendChild(op);
            }
        }

        let l1=document.createElement("label");
        l1.innerHTML=" Pice";
        l1.className="label2";
        divNarudzbina.appendChild(l1);

        let se1=document.createElement("select");
        se1.className="piceclass";
        divNarudzbina.appendChild(se1);

        let op2;
        for(var i=0;i<this.listaPica.length;i++)
            {
                
                if(this.listaPica[i].idRest=="Elit"==true)
                {
                    op2=document.createElement("option");
                    op2.innerHTML=this.listaPica[i].imePica;
                    op2.value=this.listaPica[i].id;
                    se1.appendChild(op2);
                }
            }

        let l2=document.createElement("label");
        l2.className="label3";
        l2.innerHTML=" Dezert ";
        divNarudzbina.appendChild(l2);

        let se2=document.createElement("select");
        se2.className="dezertclass";
        divNarudzbina.appendChild(se2);
        
        let op3; //opcija
        for(var i=0;i<this.listaDezerta.length;i++)
        {
           
            if(this.listaDezerta[i].idRest=="Elit"==true)
            {
                op3=document.createElement("option");
                op3.innerHTML=this.listaDezerta[i].imeDezerta;
                op3.value=this.listaDezerta[i].id;
                se2.appendChild(op3);
            }
        }
        
        let btnNaruci = document.createElement("button");
        btnNaruci.onclick=(ev)=>this.nadjiNarudzbinu(ms);
        btnNaruci.innerHTML="Naruci";
        host.appendChild(btnNaruci);
       
    }

    PromenaSelekta(divNarudzbina)
    {
        
        var lab=document.getElementsByClassName("label1")[0];
        divNarudzbina.removeChild(lab);
        
         lab=document.getElementsByClassName("label2")[0];
        divNarudzbina.removeChild(lab);

         lab=document.getElementsByClassName("label3")[0];
        divNarudzbina.removeChild(lab);
        
        var jelo=document.getElementsByClassName("jeloclass")[0];
        
        var b=jelo.parentNode;
        b.removeChild(jelo);
        
        var pice1=document.getElementsByClassName("piceclass")[0];
        
        var b1=pice1.parentNode;
        b1.removeChild(pice1);

        var dezert=document.getElementsByClassName("dezertclass")[0];
        
        var b2=dezert.parentNode;
        b2.removeChild(dezert);




        let l=document.createElement("label");
        l.className="label1";
        l.innerHTML=" Jela ";
         divNarudzbina.appendChild(l);

        let se=document.createElement("select");
        se.className="jeloclass";
        divNarudzbina.appendChild(se);

      

        let op;
      

        let l1=document.createElement("label");
        l1.innerHTML=" Pice";
        l1.className="label2";
        divNarudzbina.appendChild(l1);

        let se1=document.createElement("select");
        se1.className="piceclass";
        divNarudzbina.appendChild(se1);

        let op2;
        

        let l2=document.createElement("label");
        l2.className="label3";
        l2.innerHTML=" Dezert ";
        divNarudzbina.appendChild(l2);

        let se2=document.createElement("select");
        se2.className="dezertclass";
        divNarudzbina.appendChild(se2);
        
        let op3; //opcija
        



      let vadiIndex2 = this.kont.querySelector(".restoran1class");
        var ms2=vadiIndex2.options[vadiIndex2.selectedIndex].innerHTML;
       
        op=document.createElement("option");
        for(var i=0;i<this.listaJela.length;i++)
        {
            op.innerHTML="";
        }
        if(ms2=="Elit"){
            
            
            for(var i=0;i<this.listaJela.length;i++)
            {
                if(this.listaJela[i].idRest=="Elit"==true)
                {
                  
                    op=document.createElement("option");
                    op.innerHTML=this.listaJela[i].imeJela;
                 
                    op.value=this.listaJela[i].id;
                    se.appendChild(op);
                }
            }
            for(var i=0;i<this.listaPica.length;i++)
            {
                console.log(this.listaPica[i].idRest);
                if(this.listaPica[i].idRest=="Elit"==true)
                {
                    op2=document.createElement("option");
                    op2.innerHTML=this.listaPica[i].imePica;
                    op2.value=this.listaPica[i].id;
                    se1.appendChild(op2);
                }
            }

            for(var i=0;i<this.listaDezerta.length;i++)
            {
               
                if(this.listaDezerta[i].idRest=="Elit"==true)
                {
                    op3=document.createElement("option");
                    op3.innerHTML=this.listaDezerta[i].imeDezerta;
                    op3.value=this.listaDezerta[i].id;
                    se2.appendChild(op3);
                }
            }
        
      }
        else { 
      
            for(var i=0;i<this.listaJela.length;i++)
            {
                if(this.listaJela[i].idRest=="Puzle"==true)
                {
                    op=document.createElement("option");
                    op.innerHTML=this.listaJela[i].imeJela;
                    op.value=this.listaJela[i].id;
                    se.appendChild(op);
                }
            }
            for(var i=0;i<this.listaPica.length;i++)
            {
                if(this.listaPica[i].idRest=="Puzle"==true)
                {
                    op2=document.createElement("option");
                    op2.innerHTML=this.listaPica[i].imePica;
                    op2.value=this.listaPica[i].id;
                    se1.appendChild(op2);
                }
            }

            for(var i=0;i<this.listaDezerta.length;i++)
            {
                if(this.listaDezerta[i].idRest=="Puzle"==true)
                {
                    op3=document.createElement("option");
                    op3.innerHTML=this.listaDezerta[i].imeDezerta;
                    op3.value=this.listaDezerta[i].id;
                    se2.appendChild(op3);
                }
            }

        } 
    }
    nadjiNarudzbinu(ms){
        
        
     //izvlacenje iz "select" izabrano   
        let x = this.kont.querySelector(".jeloclass");
        var y=x.options[x.selectedIndex].value;
        console.log(y);
        let x1 = this.kont.querySelector(".piceclass");
        var y1=x1.options[x1.selectedIndex].value;
        console.log(y1);
        let x2 = this.kont.querySelector(".dezertclass");
        var y2=x2.options[x2.selectedIndex].value;
        console.log(y2);
    //izvlacenje iz "number" uneti broj telefona
       let optionEL1 = this.kont.querySelector(".konacniBrojclass");
        var ID1=optionEL1.value;
        console.log(ID1);

        
        //jelo dezert pice
        fetch("https://localhost:5001/Narudzbina/Narudzbina/"+y+"/"+y2+"/"+y1+"/"+ID1+"/"+ms,
        {
            method:"POST"
        }).then( s=>
            {
                console.log(s.status);
                console.log(s);
                if (s.status ==200){  this.UcitajListuNarudzbina(ID1);}
                else    if(s.status==202 || s.status==400){
                            alert("Nije validno");
                        
                        }
                  
               
        })

       
      
    }

    UcitajListuNarudzbina(ID1)
    {
        fetch("https://localhost:5001/Narudzbina/GetNarudzbinu/"+ID1,
        {
            method:"GET"
        }).then(s=>{
            if(s.ok){

                  var teloTabele = this.obrisiPrethodniSadrzaj() ;
                  let th;
        var zag=["Ime", "Prezime", "Jelo", "Dezert", "Piće"];
        zag.forEach(el=>{
            th = document.createElement("th");
            th.innerHTML=el;
            teloTabele.appendChild(th);
        })
                s.json().then(data=>{
                    data.forEach(s=>{  
                        let st = new Narudzbina(s.ime,s.prezime,s.jela,s.dezert,s.pice);
                        st.crtaj(teloTabele);
                    })
                    
                })
            }
        })
    }
    obrisiPrethodniSadrzaj()
    {
       
        var teloTabele = document.querySelector(".TabelaPodaci");
        var roditelj = teloTabele.parentNode;
        roditelj.removeChild(teloTabele);
        teloTabele = document.createElement("tbody");
        teloTabele.className="TabelaPodaci";
        roditelj.appendChild(teloTabele);
        return teloTabele;

    
    }

}


