let student = [];

getdata();



async function getdata() {
    //launcSettings.json fájl urljével nem műkődik.
    await fetch('http://localhost:48036/Student')
        .then(x => x.json())
        .then(y => {
            student = y
            console.log(student);
            Display();
        });
}

function Display()
{
    document.getElementById('resultArea').innerHTML = "";
    student.forEach(t => {
        document.getElementById('resultArea').innerHTML +=
            "<tr><td>" + t.neptunId + "</td>" +
            "<td>" + t.firstName + "</td>" +
            "<td>" + t.lastName + "</td>" +
            "<td>" + t.dateOfBirth + "</td>" +
            "<td>" + t.email + "</td>" +
            "<td>" + `<button type="button" onclick="remove(${t.neptunId})">Delete</button>`
            + "</td></tr>";
    });
}

//TODO
function create()
{
    let id = document.getElementById('neptunid').value;
    let fn = document.getElementById('firstname').value;
    let ln = document.getElementById('lastname').value;
    let date = document.getElementById('dateofbirth').value;
    let email = document.getElementById('email').value;


    fetch('http://localhost:48036/Student', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json', },
        body: JSON.stringify(
            {
                neptunId: id,
                firstName: fn,
                lastName: ln,
                dateOfBirth: date,
                email: email
            })
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getdata();
        })
        .catch((error) => { console.error('Error:', error); });
}


function remove(id) {
    fetch('http://localhost:48036/Student/' + id, {
        method: 'DELETE',
        headers: { 'Content-Type': 'application/json', },
        body: null
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getdata();
        })
        .catch((error) => { console.error('Error:', error); });
}