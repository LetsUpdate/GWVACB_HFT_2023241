async function loadAuthorStats() {
    const statsDiv = document.getElementById('authorStats');
    statsDiv.innerHTML = '<h2>Author Statistics</h2>';

    await loadOldestAuthorQuotes();
    await loadAuthorWithMostWords();
    await loadAvgQuoteLengthByAuthor();
    await loadQuoteCountByAuthor();
    statsDiv.innerHTML += '<h2>Quote Statistics</h2>';
    await loadMostPopularQuote();
}

async function loadMostPopularQuote() {
    try {
        const response = await fetch('http://localhost:5005/QuoteStat/GetMostPopularQuote');
        if (!response.ok) {
            throw new Error('Network response was not ok');
        }
        const quoteStat = await response.json();
        let content = '<h3>Most popular quote</h3><ul>';

        content += `<li>"${quoteStat.name}" - ${quoteStat.value}</li>`;

        content += '</ul>';
        document.getElementById('authorStats').innerHTML += content;
    } catch (error) {
        console.error('Error fetching the most popular quote:', error);
        document.getElementById('authorStats').innerHTML = '<p>There was an error loading the most popular quote.</p>';
    }
}

async function loadOldestAuthorQuotes() {
    try {
        const response = await fetch('http://localhost:5005/AuthorStat/GetOldestAuthorQuotes');
        const quotes = await response.json();
        let content = '<h3>Quotes from the Oldest Author</h3><ul>';
        quotes.forEach(quote => {
            content += `<li>"${quote.content}" - ${quote.title}</li>`;
        });
        content += '</ul>';
        document.getElementById('authorStats').innerHTML += content;
    } catch (error) {
        console.error('Error fetching oldest author quotes:', error);
    }
}

async function loadAuthorWithMostWords() {
    try {
        const response = await fetch('http://localhost:5005/AuthorStat/GetAuthorWithMostWords');
        const author = await response.json();
        const content = `<h3>Author with Most Words</h3><p>${author.name} (ID: ${author.id})</p>`;
        document.getElementById('authorStats').innerHTML += content;
    } catch (error) {
        console.error('Error fetching author with most words:', error);
    }
}

async function loadQuoteCountByAuthor() {
    try {
        const response = await fetch('http://localhost:5005/AuthorStat/GetQuoteCountByAuthor');
        const counts = await response.json();
        let content = '<h3>Quote Count By Author</h3><ul>';
        counts.forEach(count => {
            content += `<li>${count.name}: ${count.value} quotes</li>`;
        });
        content += '</ul>';
        document.getElementById('authorStats').innerHTML += content;
    } catch (error) {
        console.error('Error fetching quote count by author:', error);
    }
}


async function loadAvgQuoteLengthByAuthor() {
    try {
        const response = await fetch('http://localhost:5005/AuthorStat/GetAvgQuoteLengthByAuthor');
        const stats = await response.json();
        let content = '<h3>Average Quote Length By Author</h3><ul>';
        stats.forEach(stat => {
            content += `<li>${stat.name}: ${stat.value} characters</li>`;
        });
        content += '</ul>';
        document.getElementById('authorStats').innerHTML += content;
    } catch (error) {
        console.error('Error fetching average quote length by author:', error);
    }
}

loadAuthorStats();
