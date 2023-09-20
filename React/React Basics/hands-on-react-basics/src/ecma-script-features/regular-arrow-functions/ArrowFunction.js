let Person = (name) => {
    console.log('this keyword in arrow function refers to ', this, 'Mr.',name)
} 

class Obj {
    constructor(){}
    people = (name) => {
        console.log('this keyword in arrow function refers to ', this, 'Mr.',name)
    } 
    customer = function(name1) {
        console.log('this keyword in arrow function refers to ', this, 'Mr.',name1)
    }
}
const obj = new Obj();
obj.people('Nirmal');
obj.customer('Diwakar');


//Person('srimani')


function Student(name) {
    console.log('this keyword in regular function refers to ',this,'Mr.',name)
}

//Student('Suresh')