async function loadQuoteStats() {
    const statsDiv = document.getElementById('quoteStats');
    try {
        const response = await fetch('http://localhost:5005/QuoteStat/GetMostPopularQuote');
        const data = await response.json();

        const content = `
            <h2>Most Popular Quote</h2>
            <p>${data.content} (Author ID: ${data.authorId})</p>
        `;
        statsDiv.innerHTML = content;
    } catch (error) {
        console.error('Error fetching quote stats:', error);
        statsDiv.innerHTML = '<p>There was an error loading the quote statistics.</p>';
    }
}

loadQuoteStats();
