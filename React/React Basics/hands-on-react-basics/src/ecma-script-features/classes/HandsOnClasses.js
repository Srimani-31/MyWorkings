// A class is a type of function, but instead of using the keyword function to initiate it, we use the keyword class, 
//and the properties are assigned inside a constructor() method.

//creating a student class

class Student1 {
    constructor(name, age, classStudying )
    {
        this.name = name
        this.age = age
        this.classStudying = classStudying
    }
}

const studentOne = new Student1('Srimani', 20, 'Software Engineering')
console.log(studentOne)
console.log(studentOne.age, studentOne.name, studentOne.classStudying);
// ES6 (ECMAScript 2015) introduced a significant enhancement to JavaScript by introducing the concept of classes. 
// ES6 classes provide a more convenient and familiar way to work with object-oriented programming in JavaScript. 
// Here are all the important aspects of ES6 classes:

// 1. **Class Declaration**: Classes are declared using the `class` keyword, followed by the name of the class. 
//     Class names typically use PascalCase (each word capitalized).

   
   class MyClass {
     // Class members and methods go here
   }
   

// 2. **Constructor Method**: Classes can have a special method called `constructor` which is automatically called when an object of the class is created. 
// You can initialize object properties and perform setup tasks inside the constructor.

   
   class Person {
     constructor(name, age) {
       this.name = name;
       this.age = age;
     }
   }
   

// 3. **Class Methods**: You can define methods within a class, and they are automatically added to the class's prototype, 
// making them available to instances of the class.

   class Circle {
     constructor(radius) {
       this.radius = radius;
     }

     area() {
       return Math.PI * this.radius * this.radius;
     }
   }

// 4. **Instance Creation**: To create an instance of a class, you use the `new` keyword followed by the class name and any required constructor arguments.

   const person = new Person("Alice", 30);
   const circle = new Circle(5);

// 5. **Inheritance**: ES6 classes support inheritance through the `extends` keyword. 
// You can create a subclass that inherits properties and methods from a parent class.

   class Student extends Person {
     constructor(name, age, grade) {
       super(name, age); // Call the parent class constructor
       this.grade = grade;
     }
   }

// 6. **Static Methods**: You can define static methods in a class using the `static` keyword. 
// These methods are called on the class itself, not on instances of the class.

   class MathUtils {
     static square(x) {
       return x * x;
     }
   }

   const result = MathUtils.square(5); // Calling a static method

// 7. **Getter and Setter Methods**: Classes can have getter and setter methods to control access to object properties.

   class Temperature {
     constructor(celsius) {
       this.celsius = celsius;
     }

     get fahrenheit() {
       return (this.celsius * 9/5) + 32;
     }

     set fahrenheit(value) {
       this.celsius = (value - 32) * 5/9;
     }
   }

// 8. **Class Inheritance Chain**: Inheritance can form a chain where a subclass can itself be the parent of another subclass.

   class Animal {
     // ...
   }

   class Mammal extends Animal {
     // ...
   }

   class Cat extends Mammal {
     // ...
   }

// 9. **Super Keyword**: The `super` keyword is used to call methods and access properties of the parent class from a subclass.

   class ParentClass{
    constructor(){}
   }
   class ChildClass extends ParentClass {
     constructor() {
       super(); // Calls the constructor of the parent class
     }
   }

// 10. **Class Expressions**: Similar to function expressions, you can also define classes using class expressions.

    const MyClass1 = class {
      constructor() {
        // ...
      }
    };

// 11. **Hoisting**: Class declarations are not hoisted in JavaScript. You need to declare a class before using it.

   //const p = new Person1(); // This would result in an error if 'Person' isn't declared beforehand.
   //class Person1 {
     // ...
   //}

// ES6 classes provide a more structured and syntactically clear way to work with objects and inheritance in JavaScript, 
// making the language more suitable for building complex applications with object-oriented principles.

//Concept of Hoisting
sumOfTwoNumbers()

//const sumOfTwoNumbers = function(a,b){
//    return a + b
//} ends up in error
//reason: function expression syntax
console.log(sumOfTwoNumbers);
function sumOfTwoNumbers(a,b){
    return a + b;
}

console.log(sumOfTwoNumbers(2,3));