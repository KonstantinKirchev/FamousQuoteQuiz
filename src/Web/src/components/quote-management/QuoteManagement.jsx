import React, { useState } from 'react';
import './QuoteManagement.css';

const INITIAL_QUOTES = [
  { id: 1, text: "A dreamer is one who can only find his way by moonlight...", author: "Oscar Wilde" },
  { id: 2, text: "It has been said that democracy is the worst form of government...", author: "Sir Winston Churchill" },
];

const QuoteManagement = () => {
  const [quotes, setQuotes] = useState(INITIAL_QUOTES);
  const [isFormOpen, setIsFormOpen] = useState(false);
  const [currentQuote, setCurrentQuote] = useState({ id: null, text: '', author: '' });
  const [searchTerm, setSearchTerm] = useState('');
  const [sortField, setSortField] = useState('author');

  // Filtering Logic 
  const filteredQuotes = quotes.filter(q => 
    q.text.toLowerCase().includes(searchTerm.toLowerCase()) || 
    q.author.toLowerCase().includes(searchTerm.toLowerCase())
  );

  // Sorting Logic 
  const sortedQuotes = [...filteredQuotes].sort((a, b) => {
    return a[sortField].localeCompare(b[sortField]);
  });

  const handleSave = (e) => {
    e.preventDefault();
    if (currentQuote.id) {
      // Update existing quote 
      setQuotes(quotes.map(q => q.id === currentQuote.id ? currentQuote : q));
    } else {
      // Create new quote 
      setQuotes([...quotes, { ...currentQuote, id: Date.now() }]);
    }
    closeForm();
  };

  const handleDelete = (id) => {
    if (window.confirm("Are you sure you want to delete this quote?")) {
      setQuotes(quotes.filter(q => q.id !== id));
    }
  };

  const openForm = (quote = { id: null, text: '', author: '' }) => {
    setCurrentQuote(quote);
    setIsFormOpen(true);
  };

  const closeForm = () => {
    setIsFormOpen(false);
    setCurrentQuote({ id: null, text: '', author: '' });
  };

  return (
    <div className="management-container">
      <header className="mgmt-quote-header">
        <h2>Quote Management</h2>
        <button className="btn-primary" onClick={() => openForm()}>+ Add New Quote</button>
      </header>

      {/* Search and Sort Controls  */}
      <div className="controls">
        <input 
          type="text" 
          placeholder="Search by text or author..." 
          value={searchTerm}
          onChange={(e) => setSearchTerm(e.target.value)}
        />
        <select onChange={(e) => setSortField(e.target.value)} value={sortField}>
          <option value="author">Sort by Author</option>
          <option value="text">Sort by Quote</option>
        </select>
      </div>

      {/* List Quotes  */}
      <table className="quote-table">
        <thead>
          <tr>
            <th>Quote Text</th>
            <th>Author</th>
            <th>Actions</th>
          </tr>
        </thead>
        <tbody>
          {sortedQuotes.map(quote => (
            <tr key={quote.id}>
              <td className="quote-cell">{quote.text}</td>
              <td>{quote.author}</td>
              <td className="action-cells">
                <button className="btn-edit" onClick={() => openForm(quote)}>Edit</button>
                <button className="btn-delete" onClick={() => handleDelete(quote.id)}>Delete</button>
              </td>
            </tr>
          ))}
        </tbody>
      </table>

      {/* Create/Update Modal Form  */}
      {isFormOpen && (
        <div className="modal-overlay">
          <div className="modal-content">
            <h3>{currentQuote.id ? 'Update Quote' : 'Create Quote'}</h3>
            <form onSubmit={handleSave}>
              <label>Quote Text</label>
              <textarea 
                required
                value={currentQuote.text}
                onChange={(e) => setCurrentQuote({...currentQuote, text: e.target.value})}
              />
              <label>Author</label>
              <input 
                type="text" 
                required
                value={currentQuote.author}
                onChange={(e) => setCurrentQuote({...currentQuote, author: e.target.value})}
              />
              <div className="modal-actions">
                <button type="button" onClick={closeForm}>Cancel</button>
                <button type="submit" className="btn-primary">Save</button>
              </div>
            </form>
          </div>
        </div>
      )}
    </div>
  );
};

export default QuoteManagement;