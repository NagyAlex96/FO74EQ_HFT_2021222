let student = [];

//launcSettings.json fájl urljével nem műkődik.
fetch('http://localhost:48036/Student')
    .then(x => x.json())
    .then(y =>
    {
        student = y
        console.log(student);
        Display();
    });

function Display() {
    student.forEach(t =>
    {
        document.getElementById('resultArea').innerHTML +=
            "<tr><td>" + t.neptunId + "</td>" +
            "<td>" + t.firstName + "</td>" +
            "<td>" + t.lastName + "</td>" +
            "<td>" + t.dateOfBirth + "</td>" +
            "<td>" + t.email + "</td></tr>";
    });
}

function Create() {
    let name = document.getElementById('neptunid').value;
}