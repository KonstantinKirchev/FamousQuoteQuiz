import React, { useState, useEffect } from 'react';
import './QuizGame.css';

// Mock Data
const MOCK_QUOTES = [
  {
    id: 1,
    text: "A dreamer is one who can only find his way by moonlight, and his punishment is that he sees the dawn before the rest of the world.",
    author: "Oscar Wilde"
  },
  {
    id: 2,
    text: "It has been said that democracy is the worst form of government except all the others that have been tried.",
    author: "Sir Winston Churchill"
  }
];

const ALL_AUTHORS = ["Oscar Wilde", "Sir Winston Churchill", "James Baldwin", "Hector Berlioz"];

const QuizGame = ({ mode = 'binary' }) => {
  const [page, setPage] = useState('main'); // 'main' or 'settings' [cite: 11]
  const [currentIndex, setCurrentIndex] = useState(0);
  const [userAnswered, setUserAnswered] = useState(false);
  const [feedback, setFeedback] = useState('');
  const [options, setOptions] = useState([]);
  const [localMode, setLocalMode] = useState(mode);

  const currentQuote = MOCK_QUOTES[currentIndex];
  const effectiveMode = mode || localMode;

  useEffect(() => {
    setLocalMode(mode);
  }, [mode]);

  // Initialize options for Multiple Choice
  useEffect(() => {
    if (effectiveMode === 'multiple') {
      const others = ALL_AUTHORS.filter(a => a !== currentQuote.author);
      const shuffled = [currentQuote.author, ...others.slice(0, 2)].sort(() => Math.random() - 0.5);
      setOptions(shuffled);
    } else {
      // For Binary mode, we pick a random author to ask "Is it [Author]?"
      const randomAuthor = ALL_AUTHORS[Math.floor(Math.random() * ALL_AUTHORS.length)];
      setOptions([randomAuthor]);
    }
  }, [currentIndex, effectiveMode, currentQuote.author]);

  const handleAnswer = (selectedAuthor) => {
    const isCorrect = selectedAuthor === 'No' ? options[0] !== currentQuote.author : selectedAuthor === currentQuote.author;
    
    if (isCorrect) {
      setFeedback(`Correct! The right answer is: ${currentQuote.author}`);
    } else {
      setFeedback(`Sorry, you are wrong! The right answer is: ${currentQuote.author}`);
    }
    
    setUserAnswered(true);
  };

  const nextQuote = () => {
    setCurrentIndex((prev) => (prev + 1) % MOCK_QUOTES.length);
    setUserAnswered(false);
    setFeedback('');
  };

  return (
    <div className="app-container">
      {page === 'settings' ? (
        <div className="settings-page">
          <h2>Settings</h2>
          <label>
            <input 
              type="radio" 
              value="binary" 
              checked={effectiveMode === 'binary'} 
              onChange={() => setLocalMode('binary')} 
            /> Binary (Yes/No)
          </label>
          <br />
          <label>
            <input 
              type="radio" 
              value="multiple" 
              checked={effectiveMode === 'multiple'} 
              onChange={() => setLocalMode('multiple')} 
            /> Multiple Choice
          </label>
        </div>
      ) : (
        <div className="quiz-page">
          <h1>Who Said It?</h1>
          <div className="quote-box">
            <p>"{currentQuote.text}"</p>
          </div>

          {!userAnswered ? (
            <div className="answer-section">
              {effectiveMode === 'binary' ? (
                <div className="binary-mode">
                  <p className="question-author">{options[0]}?</p>
                  <div className="btn-group">
                    <button className="btn-yes" onClick={() => handleAnswer(options[0])}>Yes</button>
                    <button className="btn-no" onClick={() => handleAnswer("No")}>No</button>
                  </div>
                </div>
              ) : (
                <div className="multiple-mode">
                  {options.map(opt => (
                    <button key={opt} className="btn-choice" onClick={() => handleAnswer(opt)}>
                      {"-> " + opt}
                    </button>
                  ))}
                </div>
              )}
            </div>
          ) : (
            <div className="feedback-section">
              <p className="feedback-text">{feedback}</p>
              <button className="btn-next" onClick={nextQuote}>Next</button>
            </div>
          )}
        </div>
      )}
    </div>
  );
};

export default QuizGame;