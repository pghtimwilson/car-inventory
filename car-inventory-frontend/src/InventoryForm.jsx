import React from 'react';
import { Formik, Form, Field, ErrorMessage } from 'formik';

export default function InventoryForm() {
    const [notifier, setNotifier] = React.useState(false);

    function submitValues(values) {
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
            setNotifier(!notifier);
        })
    }

    return (
        <Formik
            onSubmit={submitValues}>
            {({ isSubmitting }) => (
                <Form>
                    <div>
                        <label>Make</label>
                        {/* Drop down with make */}
                        <Field type="make" name="make" />
                        <ErrorMessage name="make" component="div" />
                    </div>
                    <div>
                        <label>Model</label>
                        <Field type="model" name="model" />
                        <ErrorMessage name="model" component="div" />
                    </div>
                    <div>
                        <label>Year</label>
                        {/* Drop down with years */}
                        <Field type="year" name="year" />
                        <ErrorMessage name="year" component="div" />
                    </div>
                    <div>
                        <label>Type</label>
                        {/* Drop down type */}
                        <Field type="type" name="type" />
                        <ErrorMessage name="type" component="div" />
                    </div>
                    <div>
                        <label>Retail Price</label>
                        <Field type="retailPrice" name="retailPrice" />
                        <ErrorMessage name="retailPrice" component="div" />
                    </div>
                    <div>
                        <label>Quantity In Stock</label>
                        <Field type="quantityInStock" name="quantityInStock" />
                        <ErrorMessage name="quantityInStock" component="div" />
                    </div>
                    <div>
                        <label>Features</label>
                    </div>
                    <div>
                        {/* Todo Features */}
                        <button type={"submit"} disabled={isSubmitting}>Add</button>
                    </div>
                </Form>
            )}

        </Formik>
    );
}