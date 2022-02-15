
function Submit(){
    selectElement = document.getElementById('fname');
    output = selectElement.value;

    obj={Name:output,
        Surname:document.getElementById('lname').value,
        College:{
            Name:document.getElementById('college').value,
            ECTS:document.getElementById('ECTS').value
        }
}
array.push(obj);
console.log(array);
}