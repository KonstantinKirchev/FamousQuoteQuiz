import React from 'react';
import { NavLink } from 'react-router-dom';
import './Header.css';

const Header = () => {
  return (
    <header className="main-header">
      <nav className="navbar">
        {/* Left Side: Core Application Pages */}
        <div className="nav-group nav-left">
          <NavLink to="/" className={({ isActive }) => isActive ? "nav-item active" : "nav-item"}>
            Quiz Game
          </NavLink>
          <NavLink to="/settings" className={({ isActive }) => isActive ? "nav-item active" : "nav-item"}>
            Settings
          </NavLink>
          <NavLink to="/management/quotes" className={({ isActive }) => isActive ? "nav-item active" : "nav-item"}>
            Quote Management
          </NavLink>
          <NavLink to="/management/users" className={({ isActive }) => isActive ? "nav-item active" : "nav-item"}>
            User Management
          </NavLink>
          <NavLink to="/achievements" className={({ isActive }) => isActive ? "nav-item active" : "nav-item"}>
            Users Achievements
          </NavLink>
        </div>

        {/* Right Side: Auth Links */}
        <div className="nav-group nav-right">
          <NavLink to="/login" className="nav-item auth-link">
            Login
          </NavLink>
          <NavLink to="/register" className="nav-item auth-link register-btn">
            Registration
          </NavLink>
        </div>
      </nav>
    </header>
  );
};

export default Header;