const fs = require('fs');

let segments = fs.readFileSync('input.txt', 'utf-8').split('\n');

Part1(segments);
//drawMap(map);
Part2(segments);

function Part1(segments){
    let map = generateMap(1000);
    for(let i = 0; i < segments.length; i++){
        let segment = segments[i];
        let split = segment.trim().split('->');

        let point1 = split[0].split(',');
        let x1 = Number(point1[0]);
        let y1 = Number(point1[1]);

        let point2 = split[1].split(',');
        let x2 = Number(point2[0]);
        let y2 = Number(point2[1]);

        if(x1 == x2 || y1 == y2){
            let startInd;
            let endInd;
            if(x1 != x2){
                x1 < x2 ? (startInd = x1, endInd = x2) : (startInd = x2, endInd = x1); 
                let line = map[y1];
                //console.log(startInd + ' ' + endInd);
                for(let j = startInd; j <= endInd; j++){
                    line[j]++;
                }
            }else{
                y1 < y2 ? (startInd = y1, endInd = y2) : (startInd = y2, endInd = y1);   
                //console.log(startInd + ' ' + endInd);            
                for(let i = startInd; i <= endInd; i++){
                    let line = map[i];
                    line[x1]++;
                }
            }
        }
    }

    console.log(getResult(map));
}
function Part2(){
    let map = generateMap(1000);
    for(let i = 0; i < segments.length; i++){
        let segment = segments[i];
        let split = segment.trim().split('->');

        let point1 = split[0].split(',').map((coord) => Number(coord));
        let x1 = point1[0];
        let y1 = point1[1];

        let point2 = split[1].split(',').map((coord) => Number(coord));
        let x2 = point2[0];
        let y2 = point2[1];
        if((x1 == x2 & y1 == y2) || (x1 != x2 && y1 != y2)){
            //diagonals
            let startingPoint;
            let endingPoint;
            point1[0] < point2[0] ? (startingPoint = point1, endingPoint = point2) : 
                                    (startingPoint = point2, endingPoint = point1);

            let above = false; let below = false;
            endingPoint[1] > startingPoint[1] ? above = true : below = true;
            let current = startingPoint;
            map[endingPoint[1]][endingPoint[0]]++;
            while(current[0] != endingPoint[0] && current[1] != endingPoint[1]){
                map[current[1]][current[0]]++;

                if(above){
                    current[1]++;
                }else if(below){
                    current[1]--;
                }
                current[0]++;
            }
        }
        else{
            let startInd;
            let endInd;
            if(x1 != x2){
                x1 < x2 ? (startInd = x1, endInd = x2) : (startInd = x2, endInd = x1); 
                let line = map[y1];
                //console.log(startInd + ' ' + endInd);
                for(let j = startInd; j <= endInd; j++){
                    line[j]++;
                }
            }else{
                y1 < y2 ? (startInd = y1, endInd = y2) : (startInd = y2, endInd = y1);   
                //console.log(startInd + ' ' + endInd);            
                for(let i = startInd; i <= endInd; i++){
                    let line = map[i];
                    line[x1]++;
                }
            }
        }
    }

    console.log(getResult(map));
}
function generateMap(size){
    let matrix = [];
    
    for(let i = 0; i < size; i++){
        matrix.push([]);
        let line = matrix[i];
        for(let j = 0; j < size; j++){
            line.push(0);
        }
    }

    return matrix;
}
function drawMap(matrix){
    for(let i = 0; i < matrix.length; i++){
        let line = matrix[i];
        let l = '';
        for(let j = 0; j < matrix.length; j++){
            l += line[j];
        }
        console.log(l);
    }
}
function getResult(matrix){
    let result = 0;
    for(let i = 0; i < matrix.length; i++){
        for(let j = 0; j < matrix. length; j++){
            if(matrix[i][j] >= 2){
                result++;
            }
        }               
    }

    return result;
}