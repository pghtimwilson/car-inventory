import * as React from 'react';
import ReactDataGrid from 'react-data-grid';
import { useInventory } from './hooks/useInventory';

export default function InventoryGrid() {
    const inventory = useInventory();

    const columns = [
        { key: 'type', name:'Vehicle Type'},
        { key: 'make', name: 'Make'},
        { key: 'model', name: 'Model'},
        { key: 'retailPrice', name: 'Retail Price'},
    ];

    return (
        <div>
            <h3>Vehicle Data</h3>
            <ReactDataGrid 
                columns={columns}
                rowGetter={i => inventory[i]}
                rowsCount={inventory.length}
            />

        </div>
    );
}