import React, { useState } from 'react';
import './UserManagement.css';

const INITIAL_USERS = [
  { id: 1, name: "Alice Johnson", email: "alice@example.com", status: "Active" },
  { id: 2, name: "Bob Smith", email: "bob@example.com", status: "Disabled" },
];

const UserManagement = () => {
  const [users, setUsers] = useState(INITIAL_USERS);
  const [isModalOpen, setIsModalOpen] = useState(false);
  const [currentUser, setCurrentUser] = useState({ id: null, name: '', email: '', status: 'Active' });
  const [searchTerm, setSearchTerm] = useState('');
  const [filterStatus, setFilterStatus] = useState('All');

  // Filtering and Sorting logic 
  const processedUsers = users
    .filter(u => 
      (u.name.toLowerCase().includes(searchTerm.toLowerCase()) || u.email.toLowerCase().includes(searchTerm.toLowerCase())) &&
      (filterStatus === 'All' || u.status === filterStatus)
    )
    .sort((a, b) => a.name.localeCompare(b.name));

  const handleSave = (e) => {
    e.preventDefault();
    if (currentUser.id) {
      // Update User 
      setUsers(users.map(u => u.id === currentUser.id ? currentUser : u));
    } else {
      // Create User 
      setUsers([...users, { ...currentUser, id: Date.now() }]);
    }
    closeModal();
  };

  const toggleDisable = (id) => {
    // Disable/Enable User logic 
    setUsers(users.map(u => 
      u.id === id ? { ...u, status: u.status === 'Active' ? 'Disabled' : 'Active' } : u
    ));
  };

  const handleDelete = (id) => {
    // Delete User 
    if (window.confirm("Are you sure you want to delete this user?")) {
      setUsers(users.filter(u => u.id !== id));
    }
  };

  const openModal = (user = { id: null, name: '', email: '', status: 'Active' }) => {
    setCurrentUser(user);
    setIsModalOpen(true);
  };

  const closeModal = () => setIsModalOpen(false);

  return (
    <div className="mgmt-container">
      <header className="mgmt-header">
        <h2>User Management</h2>
        {/* <button className="btn-add" onClick={() => openModal()}>+ Create User</button> */}
      </header>

      {/* Sorting and Filtering UI  */}
      <div className="filter-bar">
        <input 
          type="text" 
          placeholder="Search by name or email..." 
          value={searchTerm}
          onChange={(e) => setSearchTerm(e.target.value)}
        />
        <select value={filterStatus} onChange={(e) => setFilterStatus(e.target.value)}>
          <option value="All">All Statuses</option>
          <option value="Active">Active</option>
          <option value="Disabled">Disabled</option>
        </select>
      </div>

      {/* List Users  */}
      <table className="user-table">
        <thead>
          <tr>
            <th>Name</th>
            <th>Email</th>
            <th>Status</th>
            <th>Actions</th>
          </tr>
        </thead>
        <tbody>
          {processedUsers.map(user => (
            <tr key={user.id} className={user.status === 'Disabled' ? 'row-disabled' : ''}>
              <td>{user.name}</td>
              <td>{user.email}</td>
              <td>
                <span className={`status-badge ${user.status.toLowerCase()}`}>
                  {user.status}
                </span>
              </td>
              <td className="action-buttons">
                <button className="btn-edit" onClick={() => openModal(user)}>Edit</button>
                <button 
                  className={user.status === 'Active' ? "btn-disable" : "btn-enable"} 
                  onClick={() => toggleDisable(user.id)}
                >
                  {user.status === 'Active' ? 'Disable' : 'Enable'}
                </button>
                <button className="btn-delete" onClick={() => handleDelete(user.id)}>Delete</button>
              </td>
            </tr>
          ))}
        </tbody>
      </table>

      {/* Modal for Create/Update  */}
      {isModalOpen && (
        <div className="modal-overlay">
          <div className="modal-card">
            <h3>{currentUser.id ? 'Update User' : 'Create User'}</h3>
            <form onSubmit={handleSave}>
              <div className="form-group">
                <label>Full Name</label>
                <input 
                  required 
                  value={currentUser.name} 
                  onChange={(e) => setCurrentUser({...currentUser, name: e.target.value})}
                />
              </div>
              <div className="form-group">
                <label>Email Address</label>
                <input 
                  type="email" 
                  required 
                  value={currentUser.email} 
                  onChange={(e) => setCurrentUser({...currentUser, email: e.target.value})}
                />
              </div>
              <div className="modal-footer">
                <button type="button" onClick={closeModal}>Cancel</button>
                <button type="submit" className="btn-save">Save Changes</button>
              </div>
            </form>
          </div>
        </div>
      )}
    </div>
  );
};

export default UserManagement;