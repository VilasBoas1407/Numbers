import "./App.css";
import Grid from "@material-ui/core/Grid";
import TextField from "@material-ui/core/TextField";
import Button from "@material-ui/core/Button";
import ListItem from "@material-ui/core/ListItem";
import ListItemText from "@material-ui/core/ListItemText";
import ListItemIcon from "@material-ui/core/ListItemIcon";

import React, { useState } from "react";
import api from "./api";

function App() {
  const [number, setNumber] = useState(0);
  const [primeNumbers, setPrimeNumbers] = useState([]);
  const [divisorsNumbers, setDivisorsNumbers] = useState([]);

  function handleChange(event) {
    setNumber(event.target.value);
  }

  function send() {
    setPrimeNumbers([]);
    setDivisorsNumbers([]);
    api
      .request({
        method: "GET",
        url: `/number/${number}`,
      })
      .then((response) => {
        if (response.data) {
          setPrimeNumbers(response.data.primeNumbers);
          setDivisorsNumbers(response.data.divisorsNumbers);
        }
      });
  }

  function returnNumberInfo() {
    if (primeNumbers.length > 0 && divisorsNumbers.length > 0) {
      return (
        <div className="number-body">
          <Grid container justifyContent="center" spacing={3}>
            <Grid item xs={6}>
              <div className="title">
                <label>Números Primos</label>
              </div>
              {primeNumbers.map((item, index) => (
                <ListItem component="div" key={index} disablePadding>
                  <ListItemIcon>
                    <ListItemText primary={item} />
                  </ListItemIcon>
                </ListItem>
              ))}
            </Grid>
            <Grid item xs={6}>
              <div className="title">
                <label>Divisores</label>
              </div>
              {divisorsNumbers.map((item, index) => (
                <ListItem component="div" key={index} disablePadding>
                  <ListItemIcon>
                    <ListItemText primary={item} />
                  </ListItemIcon>
                </ListItem>
              ))}
            </Grid>
          </Grid>
        </div>
      );
    }
  }

  return (
    <div className="App">
      <header className="header">Números e Divisores</header>
      <Grid justifyContent="center" spacing={2}>
        <TextField
          label="Digite um número"
          id="outlined-size-small"
          variant="outlined"
          size="small"
          type="number"
          onChange={handleChange}
        />
        <br />
        <br />
        <Button variant="contained" onClick={() => send()}>
          Buscar
        </Button>
        {returnNumberInfo()}
      </Grid>
    </div>
  );
}

export default App;
