import "./App.css";
import * as React from 'react';
import ReactDataGrid from 'react-data-grid';
import { useInventory } from './hooks/useInventory';
import InventoryForm from './InventoryForm';
import TotalSellingPrice from './TotalSellingPrice';
import TotalPotentialProfit from './TotalPotentialPofit';


export default function InventoryGrid() {
    const [notifier, setNotifier] = React.useState(false);
    var inventory = useInventory(notifier);

    const columns = [
        { key: 'id', name:'Id'},
        { key: 'make', name: 'Make'},
        { key: 'model', name: 'Model'},
        { key: 'year', name: 'Year' },
        { key: 'type', name: 'Vehicle Type'},
        { key: 'features', name: 'Features'},
        { key: 'formattedCalculatedSalesPrice', name: 'Calculated Sales Price'},
        { key: 'action', name: ''}
    ];

    function getCellActions(column, row) {
        const cellActions = [
            {
                icon: <span className="glyphicon glyphicon-remove">Delete</span>,
                callback: () => {
                    var foundIndex = -1;
                    for(var i = 0; i < inventory.length; i++){
                        if(inventory[i].id == row.id){
                            foundIndex = i;
                        }
                    }

                    if(foundIndex >= 0){
                        inventory.splice(foundIndex, 1);
                    }

                    var requestHeaders = new Headers();
                    requestHeaders.append('Accept', 'application/json');
                    requestHeaders.append('Content-Type', 'application/json');
                    requestHeaders.append('Access-Control-Allow-Origin', '*');
                    requestHeaders.append('Access-Control-Allow-Headers', '*');

                    var requestObject = {
                        method: 'Delete',
                        headers: requestHeaders,
                    };
            
                    fetch('https://localhost:44320/api/inventory/' + row.id, requestObject).then((results) => setNotifier(!notifier));
                }
            }
        ];

        return column.key === "action" ? cellActions : null;
    }

    return (
        <div>
            <InventoryForm></InventoryForm>
            <TotalPotentialProfit notifier={notifier} />
            <TotalSellingPrice notifier={notifier} />
            <br/>
            <h3>Vehicle Data</h3>
            <ReactDataGrid 
                columns={columns}
                rowGetter={i => inventory[i]}
                rowsCount={inventory.length}
                minHeight={500}
                getCellActions={getCellActions}
            />
        </div>
    );
}