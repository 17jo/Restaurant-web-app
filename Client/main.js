import { Dezert } from "./Dezert.js";
import { Jela } from "./Jela.js";
import { Pica } from "./Pica.js";
import { RestoranClass } from "./RestoranClass.js";
import { Restoran } from "./Restoran.js";



var listaDezerta=[];

fetch("https://localhost:5001/Dezert/GetDezerti")
.then(p=>{
    p.json().then(dezerti=>{
        dezerti.forEach(dezert => {
          //console.log(dezert);
            var p = new Dezert(dezert.id, dezert.imeDezerta, dezert.cena, dezert.imeRestorana)
            listaDezerta.push(p);
        });
    })
    
    var listaJela=[];

    fetch("https://localhost:5001/Jela/GetJelo")
    .then(p=>{
        p.json().then(jela=>{
          jela.forEach(jelo => {
               // console.log(jelo);
                var r = new Jela(jelo.id, jelo.imeJela,jelo.cena,jelo.imeRestorana)
               // console.log(r);
                listaJela.push(r);
            });
        })               
        
        var listaPica=[];

        fetch("https://localhost:5001/Pica/GetPica")
        .then(p=>{
             p.json().then(pica=>{
                 pica.forEach(pice => {
                    // console.log(pice);
                     var g = new Pica(pice.id, pice.imePica,pice.cena, pice.imeRestorana)
                     listaPica.push(g);
                });
                
               
              
              })
          
            var listaRestorana=[];

            fetch("https://localhost:5001/Restoran/GetRestoran")
            .then(p=>{
                p.json().then(pica=>{
                    pica.forEach(pice => {
                        // console.log(pice);
                        var g = new RestoranClass(pice.id, pice.imeRestorana);
                        listaRestorana.push(g);
                    });
                    
                    var f3=new Restoran(listaJela,listaPica,listaDezerta,listaRestorana);
                    f3.crtaj(document.body);
                })
               // console.log(listaPica);
            }) 
        }) 
    })  
})



