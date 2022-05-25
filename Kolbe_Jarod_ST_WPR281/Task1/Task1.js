let year = "2020";
let gender = "Male";
let qualification = "Diploma";

function genID(year, gender, qualification) 
{
    let conGender;
    let conQualification;

    switch (gender.toLowerCase()) {
        case "male":
            conGender = "1";
            break;
        case "female":
            conGender = "2";
            break;
        case "other":
            conGender = "3";
            break;
    }  

    switch (qualification.toLowerCase()) {
        case "higher certificate":
            conQualification = "10";
            break;
        case "diploma":
            conQualification = "20";
            break;
        case "degree":
            conQualification = "30";
            break;
    }

    let random = String(Math.floor(Math.random()*900+100));

    let ID = year + conGender + conQualification + random;
    return Number(ID);
}

let studentID = genID(year, gender, qualification);
console.log(studentID)
