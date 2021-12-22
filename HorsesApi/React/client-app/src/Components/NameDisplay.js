import React, { useState, useEffect } from "react";
import {Card, Button, ButtonGroup, Paper, Tooltip} from "@mui/material";

const NameDisplay = props => {

    const [error, setError] = useState(null);
    const [isLoaded, setIsLoaded] = useState(false);
    const [items, setItems] = useState({});

    let choice = 1;
    
    const callApi = choice => {
        fetch("https://localhost:7231/api/HorseName/1")
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
    
    return (
        <>
            <Card className="card">
                <Paper className="card-data-display" elevation={3}>
                    <div className="name-lastname">
                        <Tooltip title={items.firstTooltip}>
                            <h1>{items.firstName}</h1>
                        </Tooltip>
                        <Tooltip title={items.lastTooltip}>
                            <h1>{items.lastName}</h1>
                        </Tooltip>
                    </div>
                </Paper>
                <ButtonGroup className="card-buttons">
                    <Button className="button" onClick={() => callApi(0)}>Noun</Button>
                    <Button className="button" onClick={() => callApi(1)}>Plural</Button>
                    <Button className="button" onClick={() => callApi(2)}>Adverb</Button>
                    <Button className="button" onClick={() => callApi(3)}>Verb</Button>
                    <Button className="button" onClick={() => callApi(4)}>Imperative</Button>
                    <Button className="button" onClick={() => callApi(5)}>Adverb</Button>
                </ButtonGroup>
                <ButtonGroup className="card-buttons">
                    <Button className="button" onClick={() => callApi(6)}>Plural</Button>
                    <Button className="button" onClick={() => callApi(7)}>Connected</Button>
                    <Button className="button"onClick={() => callApi(8)}>Preposition</Button>
                    <Button className="button"onClick={() => callApi(9)}>Tense</Button>
                    <Button className="button"onClick={() => callApi(10)}>Superlative</Button>
                    <Button className="button"onClick={() => callApi(11)}>Conjugation</Button>
                </ButtonGroup>
            </Card>
        </>
    );
}
export default NameDisplay;
