import React, { useState } from 'react';
import { Routes, Route } from 'react-router-dom';
import QuoteManagement from './components/quote-management/QuoteManagement';
import QuizGame from './components/quiz-game/QuizGame';
import UserManagement from './components/user-management/UserManagement';
import UserAchievements from './components/user-achievements/UserAchievements';
import Header from './components/header/Header';
import Login from './components/auth/login/Login';
import Register from './components/auth/register/Register';
import Settings from './components/settings/Settings';

const App = () => {
  const [mode, setMode] = useState('binary');

  const handleModeChange = (newMode) => {
    setMode(newMode);
  };

  return (
    <>
      <Header />
      <Routes>
        <Route path="/" element={<QuizGame mode={mode} />} />
        <Route path="/settings" element={<Settings currentMode={mode} onModeChange={handleModeChange} />} />
        <Route path="/achievements" element={<UserAchievements />} />
        <Route path="/management/quotes" element={<QuoteManagement />} />
        <Route path="/management/users" element={<UserManagement />} />
        <Route path="/login" element={<Login />} />
        <Route path="/register" element={<Register />} />
      </Routes>
    </>
  );
};

export default App;