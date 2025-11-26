const fs = require('fs');

let input = fs.readFileSync('input.txt', 'utf-8').split(',').map((num) => Number(num));

Part1(input);
Part2(input);

function Part1(array){
    
    array.sort((a, b) => a - b);
    let med = array[array.length/2];

    let sum = 0;
    array.forEach(element => {
        sum += Math.abs(element - med);
    });

    console.log(sum);
}
function Part2(array){
    input.sort((a, b) => a - b);

    let bestCost = 9999999999;
    for(let i = 0; i < 2000; i++){
        let totalDistToX = 0;
        for(let j = 0; j < array.length; j++){
            let dist = Math.abs(i - array[j]);
            totalDistToX += getDist(dist);
        }
        if(totalDistToX < bestCost){
            bestCost = totalDistToX;
        }
    }
    console.log(bestCost);
}

function getDist(n){
    return n * (n+1) / 2;
}