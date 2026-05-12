import React, { useState } from 'react';
import './UserAchievements.css';

// Mock Data representing user game history
const GAME_HISTORY = [
  { id: 101, username: "Alice Johnson", quote: "A dreamer is one who...", answer: "Oscar Wilde", correctAuthor: "Oscar Wilde", status: "Correct", date: "2023-10-24" },
  { id: 102, username: "Bob Smith", quote: "It has been said that democracy...", answer: "Hector Berlioz", correctAuthor: "Sir Winston Churchill", status: "Wrong", date: "2023-10-25" },
  { id: 103, username: "Alice Johnson", quote: "It has been said that democracy...", answer: "Sir Winston Churchill", correctAuthor: "Sir Winston Churchill", status: "Correct", date: "2023-10-26" },
];

const UserAchievements = () => {
  const [history] = useState(GAME_HISTORY);
  const [searchTerm, setSearchTerm] = useState('');
  const [filterStatus, setFilterStatus] = useState('All');
  const [sortOrder, setSortOrder] = useState('newest');

  // Filtering and Sorting Logic 
  const filteredHistory = history
    .filter(item => 
      (item.username.toLowerCase().includes(searchTerm.toLowerCase()) || 
       item.quote.toLowerCase().includes(searchTerm.toLowerCase())) &&
      (filterStatus === 'All' || item.status === filterStatus)
    )
    .sort((a, b) => {
      if (sortOrder === 'newest') return new Date(b.date) - new Date(a.date);
      if (sortOrder === 'oldest') return new Date(a.date) - new Date(b.date);
      return 0;
    });

  return (
    <div className="achievements-container">
      <header className="achievements-header">
        <h2>User Achievements</h2>
        <p>Review how users answered specific quiz questions.</p>
      </header>

      {/* Filter and Sort Bar  */}
      <div className="filter-controls">
        <input 
          type="text" 
          placeholder="Search by user or quote content..." 
          value={searchTerm}
          onChange={(e) => setSearchTerm(e.target.value)}
          className="search-input"
        />
        <select value={filterStatus} onChange={(e) => setFilterStatus(e.target.value)}>
          <option value="All">All Results</option>
          <option value="Correct">Correct Only</option>
          <option value="Wrong">Wrong Only</option>
        </select>
        <select value={sortOrder} onChange={(e) => setSortOrder(e.target.value)}>
          <option value="newest">Newest First</option>
          <option value="oldest">Oldest First</option>
        </select>
      </div>

      {/* Achievements Table */}
      <div className="table-responsive">
        <table className="achievements-table">
          <thead>
            <tr>
              <th>Date</th>
              <th>User</th>
              <th>Quote Excerpt</th>
              <th>User Answer</th>
              <th>Status</th>
            </tr>
          </thead>
          <tbody>
            {filteredHistory.map(item => (
              <tr key={item.id}>
                <td>{item.date}</td>
                <td><strong>{item.username}</strong></td>
                <td className="quote-cell">"{item.quote}"</td>
                <td>{item.answer}</td>
                <td>
                  <span className={`status-pill ${item.status.toLowerCase()}`}>
                    {item.status}
                  </span>
                </td>
              </tr>
            ))}
          </tbody>
        </table>
      </div>
    </div>
  );
};

export default UserAchievements;