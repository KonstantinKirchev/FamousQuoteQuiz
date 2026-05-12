import React from 'react';
import { useNavigate } from 'react-router-dom';
import './Settings.css';

const Settings = ({ currentMode, onModeChange }) => {
  const navigate = useNavigate();

  const handleChange = (newMode) => {
    onModeChange(newMode);
    navigate('/');
  };

  return (
    <div className="settings-container">
      <div className="settings-card">
        <h2 className="settings-title">Quiz Settings</h2>
        <p className="settings-description">
          Select how you would like to guess the authors of the famous quotes.
        </p>

        <div className="mode-options">
          {/* Binary Mode Option */}
          <label className={`mode-option ${currentMode === 'binary' ? 'selected' : ''}`}>
            <input
              type="radio"
              name="quizMode"
              value="binary"
              checked={currentMode === 'binary'}
              onChange={() => handleChange('binary')}
            />
            <div className="mode-details">
              <span className="mode-name">Binary Mode (Yes/No)</span>
              <span className="mode-desc">The system asks if a specific author said the quote.</span>
            </div>
          </label>

          {/* Multiple Choice Option */}
          <label className={`mode-option ${currentMode === 'multiple' ? 'selected' : ''}`}>
            <input
              type="radio"
              name="quizMode"
              value="multiple"
              checked={currentMode === 'multiple'}
              onChange={() => handleChange('multiple')}
            />
            <div className="mode-details">
              <span className="mode-name">Multiple Choice</span>
              <span className="mode-desc">Choose the correct author from three possible answers.</span>
            </div>
          </label>
        </div>
        
        <div className="settings-footer">
          <p>Default mode is Binary (Yes/No).</p>
        </div>
      </div>
    </div>
  );
};

export default Settings;