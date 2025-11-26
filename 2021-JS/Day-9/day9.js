const fs = require('fs');

let data = fs.readFileSync('input.txt', 'utf-8');

let map = data.split('\n');
for(let i = 0; i < map.length; i++){
    if(i != map.length-1){
        map[i] = map[i].slice(0, map[i].length - 1);
    }
}

Part1(map);
Part2(map);

function Part1(map){
    let sum = 0;

    for(let i = 0; i < map.length; i++){
        let row = map[i];
        for(let j = 0; j < row.length; j++){
            if(isLowPoint(map, i, j)){
                let riskLevel = 1 + Number(row[j]);               
                sum += riskLevel;
            }
        }
        //console.log(sum);
    }

    console.log(sum);
}
function Part2(map){

    let visited = [];
    for(let i = 0; i < map.length; i++){
        visited.push([]);
        for(let j = 0; j < map[0].length; j++){
            visited[i].push(false);
        }
    }

    let basins = [];
    for(let i = 0; i < map.length; i++){
        for(let j = 0; j < map[0].length; j++){
            if(map[i][j] != '9' && !visited[i][j]){
                basins.push(getBasinSize(map, visited, i, j, 1));
            }
        }
    }

    //console.log(basins);
    basins.sort((a,b) => b - a);
    //console.log(basins);
    console.log(basins[0] * basins[1] * basins[2]);
}

function isLowPoint(map, rowInd, colInd){
    let row = map[rowInd];
    let val = row[colInd];

    if(colInd - 1 >= 0 && row[colInd-1] <= val){
        return false;
    }
    if(colInd + 1 < row.length && row[colInd+1] <= val){
        return false;
    }
    if(rowInd - 1 >= 0){
        let rowAbove = map[rowInd-1];
        if(rowAbove[colInd] <= val){
            return false;
        }
    }
    if(rowInd + 1 < map.length){
        let rowBelow = map[rowInd+1];
        if(rowBelow[colInd] <= val){
            return false;
        }
    }

    return true;
}

function getBasinSize(map, visited, i, j, count){
    visited[i][j] = true;
    
    if(j - 1 >= 0 && map[i][j-1] != '9' && !visited[i][j-1]){
        count = getBasinSize(map, visited, i, j - 1, count + 1);
    }
    if(j + 1 < map[0].length && map[i][j+1] != '9' && !visited[i][j+1]){
        count = getBasinSize(map, visited, i, j + 1, count + 1);
    }
    if(i - 1 >= 0){
        if(map[i-1][j] != '9' && !visited[i-1][j]){
            count = getBasinSize(map, visited, i - 1, j, count + 1);
        }
    }
    if(i + 1 < map.length){
        if(map[i+1][j] != '9' && !visited[i+1][j]){
            count = getBasinSize(map, visited, i + 1, j, count + 1);
        }
    }

    return count;
}