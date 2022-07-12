console.log("---1. Cars array created---")
var cars = ["Saab", "Volvo", "BMW"];
GetCars(cars);

console.log("---2. First item of array is changed---")
cars[0] = "Saab-changed";
console.log(cars[0])
console.log("---3. Last item of the array is removed---")
cars.pop(2);
GetCars(cars);

console.log("---4. Added new item Audi---")
cars.push("Audi");
GetCars(cars);

console.log("---5. Second and third item removed---")
cars.splice(1,2);
GetCars(cars);

function GetCars(array){
    for (let i = 0; i < cars.length; i++){
        console.log(cars[i]);
    }
}