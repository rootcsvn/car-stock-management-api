import React, { useState } from 'react';

function AddCarForm({ dealerId }) {
    const [car, setCar] = useState({ make: '', model: '', year: 0, stock: 0 });

    const handleSubmit = (e) => {
    e.preventDefault();
    fetch(`/api/cars/${dealerId}/add`, {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify(car),
    })
        .then((response) => response.json())
        .then((data) => {
        console.log('Car added:', data);
        })
        .catch((error) => {
        console.error('Error:', error);
        });
    };

    return (
    <form onSubmit={handleSubmit}>
        <label>
        Make:
        <input type="text" value={car.make} onChange={(e) => setCar({ ...car, make: e.target.value })} />
        </label>
        <label>
        Model:
        <input type="text" value={car.model} onChange={(e) => setCar({ ...car, model: e.target.value })} />
        </label>
        <label>
        Year:
        <input type="number" value={car.year} onChange={(e) => setCar({ ...car, year: parseInt(e.target.value) })} />
        </label>
        <label>
        Stock:
        <input type="number" value={car.stock} onChange={(e) => setCar({ ...car, stock: parseInt(e.target.value) })} />
        </label>
        <button type="submit">Add Car</button>
    </form>
    );
}

export default AddCarForm;