let quotes = [];
let connection = null;
getData();
setupSignalR();

function setupSignalR() {
    connection = new signalR.HubConnectionBuilder()
        .withUrl("http://localhost:5005/hub")
        .configureLogging(signalR.LogLevel.Information)
        .build();

    connection.on("QuoteCreated", function () {
        getData();
    });

    connection.on("QuoteDeleted", function () {
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
    const response = await fetch('http://localhost:5005/Quote');
    quotes = await response.json();
    display();
}

function display() {
    const resultArea = document.getElementById('resultarea');
    resultArea.innerHTML = "";
    quotes.forEach(quote => {
        resultArea.innerHTML +=
            `<tr>
                <td>${quote.id}</td>
                <td>${quote.title}</td>
                <td>${quote.content}</td>
                <td>${quote.authorId}</td>
                <td>
                    <button type="button" onclick="removeQuote(${quote.id})">Delete</button>
                    <button type="button" onclick="prepareUpdate(${quote.id}, '${quote.title}', '${quote.content}', ${quote.authorId})">Update</button>
                </td>
            </tr>`;
    });
}

async function removeQuote(id) {
    await fetch(`http://localhost:5005/Quote/${id}`, {
        method: 'DELETE'
    });
    getData();
}

function createQuote() {
    const title = document.getElementById('quotetitle').value;
    const content = document.getElementById('quotecontent').value;
    const authorId = document.getElementById('quoteauthorid').value;

    fetch('http://localhost:5005/Quote', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json',
        },
        body: JSON.stringify({ title, content, authorId: parseInt(authorId, 10) })
    }).then(response => {
        if (response.ok) {
            getData();
        }
    });
}

function prepareUpdate(id, title, content, authorId) {
    document.getElementById('quotetitle').value = title;
    document.getElementById('quotecontent').value = content;
    document.getElementById('quoteauthorid').value = authorId;
    const button = document.getElementById('quoteactionbutton');
    button.innerText = 'Update Quote';
    button.onclick = function () { updateQuote(id); };
}

function updateQuote(id) {
    const title = document.getElementById('quotetitle').value;
    const content = document.getElementById('quotecontent').value;
    const authorId = document.getElementById('quoteauthorid').value;

    fetch(`http://localhost:5005/Quote`, {
        method: 'PUT',
        headers: {
            'Content-Type': 'application/json',
        },
        body: JSON.stringify({ id, title, content, authorId: parseInt(authorId, 10) })
    }).then(response => {
        if (response.ok) {
            getData();
            resetForm();
        }
    });
}

function resetForm() {
    document.getElementById('quotetitle').value = '';
    document.getElementById('quotecontent').value = '';
    document.getElementById('quoteauthorid').value = '';
    document.getElementById('quoteactionbutton').innerText = 'Add Quote';
    document.getElementById('quoteactionbutton').onclick = createQuote;
}
