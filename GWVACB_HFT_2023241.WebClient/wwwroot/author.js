let authors = [];
let connection = null;
getData();
setupSignalR();

function setupSignalR() {
    connection = new signalR.HubConnectionBuilder()
        .withUrl("http://localhost:5005/hub")
        .configureLogging(signalR.LogLevel.Information)
        .build();

    connection.on("AuthorCreated", (user, message) => {
        getData();
    });

    connection.on("AuthorDeleted", (user, message) => {
        getData();
    });

    connection.onclose(async () => {
        await start();
    });
    start();
}

async function start() {
    try {
        await connection.start();
        console.log("SignalR Connected.");
    } catch (err) {
        console.log(err);
        setTimeout(start, 5000);
    }
}

async function getData() {
    await fetch('http://localhost:5005/Author')
        .then(x => x.json())
        .then(y => {
            authors = y;
            display();
        });
}

function display() {
    document.getElementById('resultarea').innerHTML = "";
    authors.forEach(t => {
        document.getElementById('resultarea').innerHTML +=
            `<tr><td>${t.id}</td><td>${t.name}</td><td>${t.age}</td><td>${t.country || ''}</td><td>` +
            `<button type="button" onclick="removeAuthor(${t.id})">Delete</button>` +
            `<button type="button" onclick="prepareUpdate(${t.id}, '${t.name}', ${t.age}, '${t.country || ''}')">Update</button>` +
            `</td></tr>`;
    });
}

function removeAuthor(id) {
    fetch(`http://localhost:5005/Author/${id}`, {
        method: 'DELETE'
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getData();
        })
        .catch((error) => {
            console.error('Error:', error);
        });
}

function createAuthor() {
    let name = document.getElementById('authorname').value;
    let age = document.getElementById('authorage').value;
    let country = document.getElementById('authorcountry').value;
    let actionButton = document.getElementById('authoractionbutton');

    if (actionButton.textContent.includes('Add')) {
        fetch('http://localhost:5005/Author', {
            method: 'POST',
            headers: { 'Content-Type': 'application/json', },
            body: JSON.stringify({ name, age: parseInt(age), country })
        })
            .then(response => response)
            .then(data => {
                console.log('Success:', data);
                getData();
            })
            .catch((error) => {
                console.error('Error:', error);
            });
    } else {
        updateAuthor(actionButton.getAttribute('data-id'));
    }
}

function prepareUpdate(id, name, age, country) {
    document.getElementById('authorname').value = name;
    document.getElementById('authorage').value = age;
    document.getElementById('authorcountry').value = country || '';
    let actionButton = document.getElementById('authoractionbutton');
    actionButton.innerText = 'Update Author';
    actionButton.setAttribute('data-id', id); // Storing ID in data attribute for update
}

function updateAuthor() {
    let id = document.getElementById('authoractionbutton').getAttribute('data-id');
    let name = document.getElementById('authorname').value;
    let age = document.getElementById('authorage').value;
    let country = document.getElementById('authorcountry').value;

    // Construct the author object, including the id for the update operation
    let author = {
        id: parseInt(id, 10), // Ensure the id is an integer
        name: name,
        age: parseInt(age, 10), // Ensure age is an integer
        country: country
    };

    fetch('http://localhost:5005/Author', {
        method: 'PUT', 
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify(author)
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getData(); // Refresh the authors list
            resetForm(); // Clear the form fields and reset the action button
        })
        .catch((error) => {
            console.error('Error:', error);
        });
}


function resetForm() {
    document.getElementById('authorname').value = '';
    document.getElementById('authorage').value = '';
    document.getElementById('authorcountry').value = '';
    let actionButton = document.getElementById('authoractionbutton');
    actionButton.innerText = 'Add Author';
    actionButton.removeAttribute('data-id');
}
