//Задача №1


interface Student {
    name: string;
    avgMark: number;
}

interface Statistics {
    avgMark: number;
    highestMark: string;
    lowestMark: string;
}

function getStatistics(marks: Student[]): Statistics {
    let result: Statistics = {
        highestMark : marks[0].name,
        lowestMark : marks[0].name,
        avgMark : marks[0].avgMark
    };

    for (let i = 1; i < marks.length; i++) {
        if (marks[i].avgMark > marks[i - 1].avgMark) {
            result.highestMark = marks[i].name;
        }

        if (marks[i].avgMark < marks[i - 1].avgMark) {
            result.lowestMark = marks[i].name;
        }

        result.avgMark += marks[i].avgMark;
    }

    result.avgMark /= marks.length;

    return result;
}

const testMarks = [{
    name: 'Vasya',
    avgMark: 3.75
}, {
    name: 'Lena',
    avgMark: 4.89
}]

console.log(getStatistics(testMarks))