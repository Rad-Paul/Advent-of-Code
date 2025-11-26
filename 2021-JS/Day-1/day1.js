const fs = require('fs');

const filePath = "D:\\coding\\Personal\\AdventOfCode\\2021\\Day-1\\input.txt";

let stream = fs.createReadStream(filePath, "utf-8");
let data = "";
stream.on('data', (chunk) => {
    data = chunk;
    Part1(data);
    Part2(data);
});
stream.on('end', () => {
    console.log('End of stream');
});

function Part1(input){

    const lines = input.split('\n');
    let counter = 0;
    for(let i = 0; i < lines.length; i++){
        if(Number(lines[i-1]) < Number(lines[i])) {
            counter++;
        }
    }

    console.log(counter);
}

function Part2(input){
    let counter = 0;
    const lines = input.split('\n');
    let lastSum = 0;
    for(let i = 0; i < 3; i++){
        lastSum += Number(lines[i]);
    }
    
    for(let i = 3; i < lines.length; i++){
        let n = Number(lines[i]);
        let tail = Number(lines[i-3]);
        if(lastSum + n - tail > lastSum){
            counter++;
        }
        lastSum -= tail;
        lastSum += n;
    }

    console.log(counter);
}

function processLine(line) {
    console.log('Processed line:', String(line));
    // You can perform any further processing on each line here
}