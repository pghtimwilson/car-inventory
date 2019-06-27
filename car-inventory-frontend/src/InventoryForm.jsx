import React from 'react';
import { Formik } from 'formik';

export default function InventoryForm() {
    return (
        <Formik>
            {/* Drop down with make */}
            <Field type="make" name="make" />
            <ErrorMessage name="make" component="div" />

            <Field type="model" name="model" />
            <ErrorMessage name="model" component="div" />

            {/* Drop down with years */}
            <Field type="year" name="year" />
            <ErrorMessage name="year" component="div" />

            {/* Drop down type */}
            <Field type="type" name="type" />
            <ErrorMessage name="type" component="div" />
        

            <Field type="retailPrice" name="retailPrice" />
            <ErrorMessage name="retailPrice" component="div" />
        
            <Field type="quantityInStock" name="quantityInStock" />
            <ErrorMessage name="quantityInStock" component="div" />
        
            {/* Todo Features */}
        </Formik>
    );
}