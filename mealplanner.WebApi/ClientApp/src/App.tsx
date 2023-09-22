import React, { Component } from 'react';
import { Route, Routes } from 'react-router-dom';
import AppRoutes from './AppRoutes';
import Layout from "layout/Layout";
import './custom.css';
import { SnackBarProvider } from 'components/SnackBar/CustomSnackBar';

export default class App extends Component {
  static displayName = App.name;

  render() {
    return (
      <SnackBarProvider>
        <Routes>
          <Route path="/" element={<Layout />}>
            {AppRoutes.map((route, index) => {
              return <Route key={index} path={route.path} element={route.element} />;
            })}
          </Route>
        </Routes>
      </SnackBarProvider>
    );
  }
}
