let comments = [];
let connection = null;
getData();
setupSignalR();

function setupSignalR() {
    connection = new signalR.HubConnectionBuilder()
        .withUrl("http://localhost:5005/hub")
        .configureLogging(signalR.LogLevel.Information)
        .build();

    connection.on("CommentCreated", function () {
        getData();
    });

    connection.on("CommentDeleted", function () {
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
    const response = await fetch('http://localhost:5005/Comment');
    comments = await response.json();
    display();
}

function display() {
    const resultArea = document.getElementById('resultarea');
    resultArea.innerHTML = "";
    comments.forEach(comment => {
        resultArea.innerHTML +=
            `<tr>
                <td>${comment.id}</td>
                <td>${comment.content}</td>
                <td>${comment.quoteId}</td>
                <td>
                    <button type="button" class="btn btn-danger" onclick="removeComment(${comment.id})">Delete</button>
                    <button type="button" class="btn btn-secondary" onclick="prepareUpdate(${comment.id}, '${comment.content}', ${comment.quoteId})">Update</button>
                </td>
            </tr>`;
    });
}

async function removeComment(id) {
    await fetch(`http://localhost:5005/Comment/${id}`, {
        method: 'DELETE'
    });
    getData();
}

function createComment() {
    const content = document.getElementById('commentcontent').value;
    const quoteId = document.getElementById('commentquoteid').value;

    fetch('http://localhost:5005/Comment', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json',
        },
        body: JSON.stringify({content, quoteId: parseInt(quoteId, 10)})
    }).then(response => {
        if (response.ok) {
            getData();
        }
    });
}

function prepareUpdate(id, content, quoteId) {
    document.getElementById('commentcontent').value = content;
    document.getElementById('commentquoteid').value = quoteId;
    const button = document.getElementById('commentactionbutton');
    button.innerText = 'Update Comment';
    button.onclick = function () {
        updateComment(id);
    };
}

function updateComment(id) {
    const content = document.getElementById('commentcontent').value;
    const quoteId = document.getElementById('commentquoteid').value;

    fetch(`http://localhost:5005/Comment`, {
        method: 'PUT',
        headers: {
            'Content-Type': 'application/json',
        },
        body: JSON.stringify({id, content, quoteId: parseInt(quoteId, 10)})
    }).then(response => {
        if (response.ok) {
            getData();
            resetForm();
        }
    });
}

function resetForm() {
    document.getElementById('commentcontent').value = '';
    document.getElementById('commentquoteid').value = '';
    document.getElementById('commentactionbutton').innerText = 'Add Comment';
    document.getElementById('commentactionbutton').onclick = createComment;
}
    