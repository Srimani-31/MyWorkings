const student = {
    name:'srimani',
    age: 20,
    games:{
        indoor: 'chess',
        outdoor:{
            trackFieldEvent: '100m dash',
            individualEvent: 'Crossfit Athlete',
            groupEvent: 'Cricket'
        }
    },
    favPerson: 'Shanthi Amma'
}

//extracting name of the student
function ExtractName( {name}){
    return 'Student Name is '+name;
}

const nameOfStudent = ExtractName(student)
console.log(nameOfStudent);

//extracting the student's games
const games = ExtractGames(student)

function ExtractGames({games})
{
    let str ='Student indoor game is '+games.indoor;
    str += `\nHe will play outdoor games like ${games.outdoor.trackFieldEvent}, ${games.outdoor.individualEvent}, ${games.outdoor.groupEvent}`
    return str
}
console.log(games)
//extracting the student's groupEvent only

const hisGroupEvent = ExtractGroupEvent(student)

function ExtractGroupEvent({games: {outdoor: {groupEvent}}}){
    console.log(`Student has involved in the group event ${groupEvent}`)
}
