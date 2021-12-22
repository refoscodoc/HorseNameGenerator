import logo from './logo.svg';
import './App.css';
import NameDisplay from './Components/NameDisplay'; 

function App() {
  return (
    <div className="App">
      <header className="App-header">
        <img src={logo} className="App-logo" alt="logo" />
        <NameDisplay />
      </header>
    </div>
  );
}

export default App;
