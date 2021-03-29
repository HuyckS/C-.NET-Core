//from leetcode 1768. Merge Strings Alternately

// You are given two strings word1 and word2. Merge the strings by 
// adding letters in alternating order, starting with word1. If a string 
// is longer than the other, append the additional letters onto the end 
// of the merged string.

// Return the merged string.

function mergeAlternately(word1, word2) {
    // take each letter one at a time and concatenate them together interchangably
    // edge case, if no words exist, return no words to concatenate
    if (word1.length === 0 && word2.length === 0) {
        return "No words to merge";
    }
    // find out which is longer
    let len = 0;
    if (word1.length === word2.length) {
        len = word1.length;
    } else {
        len = word2.length;
    }
    // create result string
    let result = "";
    // loop through using longest length
    for (let i = 0; i < len; i++) {
        // if the letter exists concatenate in the order of word1, then word2 onto result string
        if (word1[i]) {
            result = result + word1[i];
        }
        if (word2[i]) {
            result = result + word2[i];
        }
    }
    // return result string
    return result;
}

console.log(mergeAlternately("abc", "xyz"));