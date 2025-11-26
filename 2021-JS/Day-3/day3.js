
const fs = require('fs');
const { parse } = require('path');

let input = fs.readFileSync('input.txt', 'utf-8').split('\n');

Part1(input);
Part2(input);

function Part1(input){
    let gammaRate = "";
    let epsilonRate = "";
    let lineLength = input[0].length;

    for(let i = 0; i < lineLength; i++){
        litCount = 0;
        for(let j = 0; j < input.length; j++){
            let line = String(input[j]);
            if(line[i] == '1'){
                litCount++;
            }
        }
        if(litCount > input.length/2){
            gammaRate += '1';            
            epsilonRate += '0';
        }else{
            gammaRate += '0';
            epsilonRate += '1';
        }

        litCount = 0;
    }

    console.log(gammaRate + ' : ' + parseInt(gammaRate, 2));
    console.log(epsilonRate + ' : ' + parseInt(epsilonRate, 2));
    console.log(parseInt(gammaRate, 2) * parseInt(epsilonRate, 2) + "\n");
}
function Part2(input){

    let oxygenList = [];
    let scrubberList = [];
    
    for(let i = 0; i < input.length; i++){
        let line = input[i];
        if(line[0] == '1'){
            oxygenList.push(line);
        }else{
            scrubberList.push(line);
        }
    }
    
    let scrubberRating = getScrubberRating(scrubberList);
    let oxygenRating = getOxygenRating(oxygenList);

    console.log(scrubberRating + ' : ' + parseInt(scrubberRating, 2));
    console.log(oxygenRating + ' : ' + parseInt(oxygenRating, 2));
    console.log(parseInt(scrubberRating, 2) * parseInt(oxygenRating, 2) + "\n");

    function getScrubberRating(array){
        let toR = '';
        let list = array;
        let bitVal = '';
        for(let i = 1; i < list[0].length; i++){
            let temp = [];
            let litCount = 0;
            for(let j = 0; j < list.length; j++){
                let line = list[j];
                if(line[i] === '1'){
                    litCount++;
                }
            }
            
            if(litCount < list.length/2){
                bitVal = '1';
            }else{
                bitVal = '0';
            }

            for(let j = 0; j < list.length; j++){
                let line = list[j];
                if(line[i] === bitVal){
                    temp.push(line);
                }
            }
            list = temp;
            if(list.length == 1){
                toR = list[0];
                break;
            }
        }
        return toR;
    }
    function getOxygenRating(array){
        let toR = '';
        let list = array;
        let bitVal = '';
        for(let i = 1; i < list[0].length; i++){
            let temp = [];
            let litCount = 0;
            for(let j = 0; j < list.length; j++){
                let line = list[j];
                if(line[i] === '1'){
                    litCount++;
                }
            }
            if(litCount >= list.length/2){
                bitVal = '1';
            }else{
                bitVal = '0';
            }

            for(let j = 0; j < list.length; j++){
                let line = list[j];
                if(line[i] === bitVal){
                    temp.push(line);
                }
            }
            list = temp;
            if(list.length == 1){
                toR = list[0];               
                break;
            }
        }
        return toR;
    }
}