import React from 'react'
import '../Layout/Layout.css';

const About = () => {
  return (
    <div className='about-page'>
      <div className='about-container'>
        <h1>Om ActiviGo</h1>
        
        <div className='about-section'>
          <h2>Vad är ActiviGo?</h2>
          <p>
            ActiviGo är en webbplats där man kan enkelt hitta aktiviteter som händer i kommunen.
            Man kan enkelt boka in sig på dom samt se vilket typ av väder det kommer vara just 
            den tiden för utomhus aktiviteter.
          </p>
        </div>

        <div className='about-section'>
          <h2>Vår Vision</h2>
          <p>
            Vi strävar mot att användare ska ha en så bra upplevelse som möjligt när dom använder vår sida.
            Det ska vara smidigt och enkelt att hitta aktiviteter man vill göra samt att boka in sig på dom.
          </p>
        </div>
      </div>
    </div>
  );
};

export default About