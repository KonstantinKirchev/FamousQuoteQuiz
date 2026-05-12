import React, { useState, useEffect } from 'react';
import { Routes, Route } from 'react-router-dom';
import QuoteManagement from './components/quote-management/QuoteManagement';
import QuizGame from './components/quiz-game/QuizGame';
import UserManagement from './components/user-management/UserManagement';
import UserAchievements from './components/user-achievements/UserAchievements';
import Header from './components/header/Header';
import Login from './components/auth/login/Login';
import Register from './components/auth/register/Register';

const App = () => {
  return (
    <>
      <Header />
      <Routes>
        <Route path="/" element={<QuizGame />} />
        <Route path="/achievements" element={<UserAchievements />} />
        <Route path="/management/quotes" element={<QuoteManagement />} />
        <Route path="/management/users" element={<UserManagement />} />
        <Route path="/login" element={<Login />} />
        <Route path="/register" element={<Register />} />
      </Routes>
    </>
    // <>
    //   <Header />
    //   <UserManagement />
    //   <QuoteManagement />
    //   <QuizGame />
    //   <UserAchievements />
    // </>
  );
};

export default App;