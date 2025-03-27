import './App.css';
import BowlerList from './BowlerList';
import Welcome from './Welcome';

// Use App to call both the Welcome and BowlerList components
function App() {
  return (
    <>
      <Welcome />
      <BowlerList />
    </>
  );
}

export default App;
