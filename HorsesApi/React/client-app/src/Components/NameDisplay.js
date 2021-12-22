import React, { useState, useEffect } from "react";
import {Card, Button, ButtonGroup, Paper} from "@mui/material";

const NameDisplay = props => {

    const [error, setError] = useState(null);
    const [isLoaded, setIsLoaded] = useState(false);
    const [items, setItems] = useState({});

    let choice = 1;
    
    const callApi = () => {
        fetch("http://localhost:5128/api/HorseName/1")
            .then(res => res.json())
            .then(
                (result) => {
                    setIsLoaded(true);
                    setItems(result);
                },
                // Note: it's important to handle errors here
                // instead of a catch() block so that we don't swallow
                // exceptions from actual bugs in components.
                (error) => {
                    setIsLoaded(true);
                    setError(error);
                }
            )

    }    
    
    // console.log(items.data[0]);
    
    return (
        <>
            <Card className="card">
                <Paper className="card-data-display" elevation={3}>
                    <h1></h1>
                </Paper>
                <ButtonGroup className="card-buttons">
                    <Button className="button" onClick = {callApi}>One</Button>
                    <Button className="button">Two</Button>
                    <Button className="button">Three</Button>
                    <Button className="button">Four</Button>
                    <Button className="button">Five</Button>
                    <Button className="button">Six</Button>
                    <Button className="button">Seven</Button>
                    <Button className="button">Eigth</Button>    
                </ButtonGroup>
            </Card>
        </>
    );
}
export default NameDisplay;
