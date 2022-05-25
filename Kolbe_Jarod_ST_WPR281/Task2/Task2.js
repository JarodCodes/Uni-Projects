let fruit = ["apple", "peach", "strawberry", "lichi", "blueberry"]
let vegetable = ["tomato", "carrot", "avocado", "leak", "bean"]

console.log(vegetable.length)

let food = fruit.concat(vegetable)
console.log(food)

food.splice(4,2)

food.reverse

food.splice(0,1)

food.splice(0,1,'macaroni')

let foodstr = food.join(', ')
console.log(foodstr)

