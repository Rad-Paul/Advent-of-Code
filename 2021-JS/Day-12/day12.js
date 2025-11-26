const fs = require('fs');

let input = fs.readFileSync('input.txt', 'utf-8').split('\r\n');
let nodes = getNodes(input);

Part1(nodes);
Part2(nodes);

function Part1(nodes){
    let visited = new Map();
    let keyArray = Array.from(nodes.keys());
    for(let i = 0; i < keyArray.length; i++){
        visited.set(keyArray[i], false);
    }

    let count = 0;
    visited.set('start', true);
    count = getPaths(nodes, visited, nodes.get('start'), count);
    console.log(count);
}

function Part2(nodes){
    let visited = new Map();
    let keyArray = Array.from(nodes.keys());
    for(let i = 0; i < keyArray.length; i++){
        visited.set(keyArray[i], 0);
    }

    let count = 0;
    let bonus = false;
    visited.set('start', 999);
    count = getPaths2(nodes, visited, nodes.get('start'), count, bonus);
    console.log(count);
}

function getPaths(nodes, visited, node, count){
    if(node.name == 'end'){
        return count+1;
    }

    for(let i = 0; i < node.neighbours.length; i++){
        let neighbour = node.neighbours[i];
        if(neighbour[0] === neighbour[0].toUpperCase()){
            count = getPaths(nodes, visited, nodes.get(neighbour), count);
        }else if(visited.get(neighbour) == false){          
            visited.set(neighbour, true);
            count = getPaths(nodes, visited, nodes.get(neighbour), count);
            visited.set(neighbour, false);
        }
    }
    return count;
}
function getPaths2(nodes, visited, node, count, bonus){
    if(node.name == 'end'){
        return count+1;
    }
    for(let i = 0; i < node.neighbours.length; i++){
        let neighbour = node.neighbours[i];
        if(neighbour[0] === neighbour[0].toUpperCase()){
            count = getPaths2(nodes, visited, nodes.get(neighbour), count, bonus);
        }else if(visited.get(neighbour) == 0){          
            visited.set(neighbour, visited.get(neighbour)+1);
            count = getPaths2(nodes, visited, nodes.get(neighbour), count, bonus);
            visited.set(neighbour, visited.get(neighbour)-1);
        }else if(bonus == false && visited.get(neighbour) == 1){
            visited.set(neighbour, visited.get(neighbour)+1);
            bonus = true;
            count = getPaths2(nodes, visited, nodes.get(neighbour), count, bonus);
            bonus = false;
            visited.set(neighbour, visited.get(neighbour)-1);
        }
    }
    return count;
}
function getNodes(input){

    class Node{
        constructor(name){
            this.name = name;
            this.neighbours = [];
        }
        addConnection(neighbour){
            this.neighbours.push(neighbour);
        }
    }

    let nodes = new Map();
    for(let i = 0; i < input.length; i++){
        let line = input[i].split('-');
        if(!nodes.has(line[0])){
            nodes.set(line[0], new Node(line[0]));
        }
        nodes.get(line[0]).addConnection(line[1]);

        if(!nodes.has(line[1])){
            nodes.set(line[1], new Node(line[1]));
        }
        nodes.get(line[1]).addConnection(line[0]);
    }
    return nodes;
}