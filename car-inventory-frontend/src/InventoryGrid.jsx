import * as React from 'react';
import ReactDataGrid from 'react-data-grid';
import { useInventory } from './hooks/useInventory';
import TotalSellingPrice from './TotalSellingPrice';
import TotalPotentialProfit from './TotalPotentialPofit';

export default function InventoryGrid() {
    const inventory = useInventory(false);

    const columns = [
        { key: 'make', name: 'Make'},
        { key: 'model', name: 'Model'},
        { key: 'year', name: 'Year' },
        { key: 'type', name: 'Vehicle Type'},
        { key: 'features', name: 'Features'},
        { key: 'formattedCalculatedSalesPrice', name: 'Calculated Sales Price'},

    ];

    // onRowsSelected = rows => {
    //     // this.setState({
    //     //     selectedIndexes: this.state.selectedIndexes.concat(
    //     //     rows.map(r => r.rowIdx)
    //     //     )
    //     // });
    // };

    // onRowsDeselected = rows => {
    //     let rowIndexes = rows.map(r => r.rowIdx);
    //     console.log(rowIndexes);

    //     // this.setState({
    //     //     selectedIndexes: this.state.selectedIndexes.filter(
    //     //     i => rowIndexes.indexOf(i) === -1
    //     //     )
    //     // });
    // };

    return (
        <div>
            <TotalPotentialProfit />
            <TotalSellingPrice />

            <h3>Vehicle Data</h3>
            <ReactDataGrid 
                columns={columns}
                rowGetter={i => inventory[i]}
                rowsCount={inventory.length}
                minHeight={500}
                rowSelection={{
                    showCheckbox: true,
                    enableShiftSelect: true,
                    //onRowsSelected: this.onRowsSelected,
                    //onRowsDeselected: this.onRowsDeselected,
                    selectBy: {
                      //indexes: this.state.selectedIndexes
                    }
                  }}
            />
        </div>
    );
}