const fs = require('fs');

let data = fs.readFileSync('input.txt', 'utf-8').split(',');
data = data.map((element) => Number(element));

Part1(data);
Part2(data);
function Part1(array){

    for(let i = 0; i < 80; i++){
        let toAdd = 0;
        for(let j = 0; j < array.length; j++){
            array[j]--;
            if(array[j] < 0){
                array[j] = 6;
                toAdd++;
            }
        }
        for(let k = 0; k < toAdd; k++){
            array.push(8);
        }
        
        //console.log(array);
    }

    console.log(array.length);
}

function Part2(array){

    let currentDay  = { '0': 0, '1': 0, '2': 0, '3': 0, '4': 0, '5': 0, '6': 0, '7': 0, '8': 0};
    for(let i = 0; i < array.length; i++){
        if(String(array[i]) in currentDay){
            currentDay[String(array[i])]++;
        }
    }

    for(let i = 0; i < 256; i++){
        let nextDay = { '0': 0, '1': 0, '2': 0, '3': 0, '4': 0, '5': 0, '6': 0, '7': 0, '8': 0};
        for(let i = 0; i <= 8; i++){
            let key = String(i);
            if(key == '0'){
                nextDay['6'] += currentDay[key];
                nextDay['8'] += currentDay[key];
            }else{
                nextDay[Number(key) - 1] += currentDay[key];
            }
        }
        let result = '';
        for(let key in nextDay){
            result += String(nextDay[key]) + ',';
        }
        //console.log(result);
        currentDay = nextDay;
    }

    let result = 0;
    for(let key in currentDay){
        result += currentDay[key];
    }

    console.log(result);
}