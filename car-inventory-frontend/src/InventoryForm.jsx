import React from 'react';
import { Formik, Form, Field, ErrorMessage } from 'formik';
import * as yup from 'yup';
import Button from 'react-bootstrap/Button';

export default function InventoryForm(props) {

    //TODO Add numeric validation on Retail Price and Quantity In Stock
    const validationSchema = yup.object({
        make: yup.string().required("Make is required"),
        model: yup.string().required("Model is required"),
        year: yup.string().required('Year is required'),
        type: yup.string().required('Type is required'),
        retailPrice: yup.string().required('Retail Price is required'),
        quantityInStock: yup.string().required('Quantity In Stock is required')
    });

    function submitValues(values, {setSubmitting}) {
        setSubmitting(true);

        var requestHeaders = new Headers();
        requestHeaders.append('Accept', 'application/json');
        requestHeaders.append('Content-Type', 'application/json');
        requestHeaders.append('Access-Control-Allow-Origin', '*');
        requestHeaders.append('Access-Control-Allow-Headers', '*');

        var requestObject = {
            method: 'Post',
            headers: requestHeaders,
            body: JSON.stringify(values),
        };

        fetch('https://localhost:44320/api/inventory/', requestObject).then((data) => {
            props.setNotifier(!props.notifier);
            setSubmitting(false);
        })
    }

    function yearDropDownOptions(){
        //Most often times dealerships will have vehicles in their inventory for the next year.
        //For example next year's vehicles may be released as early in the previous year's fall.
        var currentYear = (new Date().getFullYear() + 1);
        var yearsToInclude = 10;
        var lastFewYears = [];

        while(yearsToInclude > 0){
            lastFewYears.push(currentYear);
            currentYear--;
            yearsToInclude--;
        }

        return (
            lastFewYears.map(year => <option key={'year_' + year} value={year}>{year}</option>)
         );
    }

    return (
        <Formik
            initialValues = {{model: ''}}
            validationSchema = {validationSchema}
            onSubmit={submitValues}>
            {({ isSubmitting }) => (
               <Form className='inventory-form'>
               <div className='sub-form'>
                   <div className='container'>
                       <label><b>Car Details</b></label>
                       <div>
                           Note: All fields are required.
                       </div>
                       <div className='data'>
                           <label>Make</label>
                           <Field component="select" name="make">
                               <option key={'make_default'} value=''>Please make a selection</option>
                               <option key={'make_chevy'} value="Chevy">Chevy</option>
                               <option key={'make_ford'} value="Ford">Ford</option>
                               <option key={'make_dodge'} value="Dodge">Dodge</option>
                               <option key={'make_jeep'} value="Jeep">Jeep</option>
                               <option key={'make_kia'} value="Kia">Kia</option>
                               <option key={'make_lincoln'} value="Lincoln">Lincoln</option>
                               <option key={'make_nissan'} value="Nissan">Nissan</option>
                               <option key={'make_tesla'} value="Tesla">Tesla</option>
                           </Field>
                           <ErrorMessage className='error' name="make" component="div" />
                       </div>
                       <div className='data'>
                            <label>Model</label>
                            <Field type="text" name="model" />
                            <ErrorMessage className='error'  name="model" component="div" />
                        </div>
                        <div className='data'>
                            <label>Year</label>
                            <Field component="select" name="year">
                                <option key={'year_default'} value=''>Please make a selection</option>
                                {yearDropDownOptions()}
                            </Field>
                            <ErrorMessage className='error'  name="year" component="div" />
                        </div>
                        <div className='data'>
                            <label>Type</label>
                            <Field component="select" name="type">
                                <option key={'type_default'} value=''>Please make a selection</option>
                                <option key={'type_car'} value="Car">Car</option>
                                <option key={'type_truck'} value="Truck">Truck</option>
                            </Field>
                            <ErrorMessage className='error'  name="type" component="div" />
                        </div>
                        <div className='data'>
                            <label>Retail Price</label>
                            <Field type="text" name="retailPrice" />
                            <ErrorMessage className='error'  name="retailPrice" component="div" />
                        </div>
                        <div className='data'>
                            <label>Quantity In Stock</label>
                            <Field type="text" name="quantityInStock" />
                            <ErrorMessage className='error'  name="quantityInStock" component="div" />
                        </div>
                        <div className='data'>
                            <label>Markup Percentage</label>
                            <Field type="text" name="markup" />
                        </div>
                   </div>
               </div>
               <div className='sub-form'>
                    <div className='container'>
                        <label><b>Features</b></label>
                        <div className='data'>
                            <label>Fuel</label>
                                <Field component="select" name="fuel">
                                    <option key={'fuel_default'} value=''></option>
                                    <option key={'fuel_electric'} value="Electric">Electric</option>
                                    <option key={'fuel_gas'} value="Gas">Gas</option>
                                    <option key={'fuel_hybrid'} value="Hybrid">Hybrid</option>
                                    <option key={'fueld_diesel'} value="Diesel">Diesel</option>
                                </Field>
                            </div>
                        <div className='data'>
                            <label>Doors</label>
                            <Field component="select" name="doors">
                                <option key={'doors_default'} value=''></option>
                                <option key={'doors_2doors'} value="2-Door">2-Doors</option>
                                <option key={'doors_4doors'} value="4-Door">4-Doors</option>
                            </Field>
                        </div>
                        <div className='data'>
                            <label>Interior</label>
                            <Field component="select" name="interior">
                                <option key={'interior_default'} value=''></option>
                                <option key={'interior_cloth'} value="Cloth">Cloth</option>
                            </Field>
                        </div>
                        <div className='data'>
                            <label>Transmission</label>
                            <Field component="select" name="transmission">
                                <option key={'transmission_default'} value=''></option>
                                <option key={'transmission_automatic'} value="Automatic">Automatic</option>
                                <option key={'transmission_manual'} value="Manual">Manual</option>
                            </Field>
                        </div>
                    </div>
                </div>
               <div className='form-submit'>
                    <Button type="submit" disabled={isSubmitting}>Add New Item</Button>
               </div>
           </Form>
            )}
        </Formik>
    );
}