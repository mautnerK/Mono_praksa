var i = 10;
console.log(i);

var obj =new Object();
var array=new Array();
var obj ={
    Name:'Karlo',
    Surname:'Mautner',
    College:{
        Name:'FERIT',
        ECTS:'45'
    }
};
array.push(obj);

var obj ={
    Name:'Filip',
    Surname:'Filic',
    College:{
        Name:'MATHOS',
        ECTS:'59'
    }
};

array.push(obj);

var obj ={
    Name:'Mislav',
    Surname:'Lic',
    College:{
        Name:'KIF',
        ECTS:'60'
    }
};
array.push(obj);
var obj ={
    Name:'Maja',
    Surname:'Saja',
    College:{
        Name:'PRAVOS',
        ECTS:'11'
    }
};
array.push(obj);

document.getElementById('option1').innerHTML=array[0].Name+' '+ array[0].Surname;    
document.getElementById('option2').innerHTML=array[1].Name+' '+ array[1].Surname;  
document.getElementById('option3').innerHTML=array[2].Name+' '+ array[2].Surname;  
document.getElementById('option4').innerHTML=array[3].Name+' '+ array[3].Surname;  

document.getElementById('Name').innerHTML="Student";    
document.getElementById('College').innerHTML="College";    
document.getElementById('ECTS').innerHTML="ECTS";    

var obj;

function getStudent() {
    var output;
    selectElement = document.getElementById('Students');
    output = selectElement.options[selectElement.selectedIndex].text;
    console.log(output);
    document.getElementById('Name').innerHTML=output;
    obj = array.find(o => o.Name ===output.split(' ')[0] && o.Surname===output.split(' ')[1] );
    console.log(obj);
    document.getElementById('College').innerHTML=obj.College.Name;
    document.getElementById('ECTS').innerHTML=obj.College.ECTS;

}

function calculateScholarship(){
    var radioValue=document.querySelector('input[name="studiranje"]:checked').value;
    var price;
    console.log(obj.College.ECTS);
    if(parseInt(obj.College.ECTS,10) < 25 || radioValue==="izvanredno"){
            price=8000;
    }
    else if (parseInt(obj.College.ECTS,10)>55){
        price = 0;
    }
    else{
        price=250*(60-parseInt(obj.College.ECTS,10));
    }
    document.getElementById('price').innerHTML=price.toString()+' kn';

}


