// Import the type bowler for the data and then useEffect and useState for setting up defaults as well as only calling the data once
import { bowler } from './types/bowler';
import { useEffect, useState } from 'react';

function BowlerList() {
  const [bowlers, setBowlers] = useState<bowler[]>([]);

  // Use useEffect() to fetch the data asynchronously from the live API and then set the bowler data as json
  useEffect(() => {
    const fetchBowler = async () => {
      const response = await fetch('https://localhost:5000/bowler');
      const data = await response.json();

      setBowlers(data);
    };
    fetchBowler();
  }, []);

  // Return table with all necessary info
  return (
    <>
      <table>
        <thead>
          <tr>
            <td>First Name</td>
            <td>Middle Initial</td>
            <td>Last Name</td>
            <td>Phone Number</td>
            <td>Address</td>
            <td>City</td>
            <td>State</td>
            <td>Zipcode</td>
            <td>Team Name</td>
          </tr>
        </thead>
        <tbody>
          {/* Parse through information held in bowlers and reference the data using the type bowler setup */}
          {bowlers.map((b) => (
            <tr key={b.bowlerId}>
              <td>{b.bowlerFirstName}</td>
              <td>{b.bowlerMiddleInit}</td>
              <td>{b.bowlerLastName}</td>
              <td>{b.bowlerPhoneNumber}</td>
              <td>{b.bowlerAddress}</td>
              <td>{b.bowlerCity}</td>
              <td>{b.bowlerState}</td>
              <td>{b.bowlerZip}</td>
              <td>{b.teamName}</td>
            </tr>
          ))}
        </tbody>
      </table>
    </>
  );
}
// Export the list for use in the App component
export default BowlerList;
