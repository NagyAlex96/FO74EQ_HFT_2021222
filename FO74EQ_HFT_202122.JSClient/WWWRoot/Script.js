let student = [];
let connection = null;
let studentUpdate = -1;

getdata();
setupSignalR();

function setupSignalR() {
    console.log("Signalr setup started")
    connection = new signalR.HubConnectionBuilder()
        .withUrl("http://localhost:48036/hub")
        .configureLogging(signalR.LogLevel.Information)
        .build();

    connection.on("StudentCreated", (user, message) => {
        console.log("Create ping received")
        getdata();
    });

    connection.on("StudentDeleted", (user, message) => {
        console.log("Delete ping received")
        getdata();
    });

    connection.on("StudentUpdated", (user, message) => {
        getdata();
    });

    connection.onclose(async () => {
        await start();
    });
    start();
    console.log("Signalr setup finished")
}

async function start() {
    try {
        await connection.start();
        console.log("SignalR Connected.");
    } catch (err) {
        console.log(err);
        setTimeout(start, 5000);
    }
};

async function getdata() {
    //launcSettings.json fájl urljével nem műkődik.
    console.log("getdata running")
    await fetch('http://localhost:48036/Student')
        .then(x => x.json())
        .then(y => {
            student = y
            console.log(student);
            Display();
        });
}

function Display() {
    document.getElementById('resultArea').innerHTML = "";
    student.forEach(t => {
        document.getElementById('resultArea').innerHTML +=
            "<tr><td>" + t.neptunId + "</td>" +
            "<td>" + t.firstName + "</td>" +
            "<td>" + t.lastName + "</td>" +
            "<td>" + t.dateOfBirth + "</td>" +
            "<td>" + t.email + "</td>" +
            "<td>" +
            `<button type="button" onclick="remove(${t.neptunId})">Delete</button>` +
            `<button type="button" onclick="showupdate(${t.neptunId})">Update</button>`
            + "</td></tr>";
    });
}

function create() {
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

function update() {

    document.getElementById('updateStudent').style.display = 'none';
    let fn = document.getElementById('updatefirstname').value;
    let ln = document.getElementById('updatelastname').value;
    let email = document.getElementById('updateemail').value;

    fetch('http://localhost:48036/Student/', {
        method: 'PUT',
        headers: { 'Content-Type': 'application/json', },
        body: JSON.stringify(
            {
                neptunId: studentUpdate,
                firstName: fn,
                lastName: ln,
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

function showupdate(id) {
    let x = student.find(t => t['neptunId'] == id);
    studentUpdate = id;

    document.getElementById('updateneptunid').value = x['neptunId'];
    document.getElementById('updatefirstname').value = x['firstName'];
    document.getElementById('updatelastname').value = x['lastName'];
    document.getElementById('updateemail').value = x['email'];

    document.getElementById('updateStudent').style.display = 'flex';
}