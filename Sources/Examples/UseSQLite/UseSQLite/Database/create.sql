CREATE TABLE version (
	version 	VARCHAR(50) PRIMARY KEY NOT NULL,
	script		VARCHAR(2000)
);

INSERT INTO version (version) VALUES ("1.0.0");