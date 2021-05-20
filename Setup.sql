CREATE TABLE accounts (
    id VARCHAR(255) NOT NULL,
    name VARCHAR(255) NOT NULL,
    email VARCHAR(255) NOT NULL,
    picture VARCHAR(255) NOT NULL,

    PRIVATE KEY (id)
)

CREATE TABLE spells (
    id INT NOT NULL AUTO_INCREMENT,
    name VARCHAR(255) NOT NULL,
    school VARCHAR(255) NOT NULL,
    description VARCHAR(255) NOT NULL,
    castingTime INT NOT NULL
    material BIT NOT NULL,
    verbal BIT NOT NULL,
    somatic BIT NOT NULL,
    concentration BIT NOT NULL,

    PRIVATE KEY (id)
)

CREATE TABLE reagents (
    id INT NOT NULL AUTO_INCREMENT,
    name VARCHAR(255) NOT NULL,
    email VARCHAR(255) NOT NULL,
    picture VARCHAR(255) NOT NULL,

    PRIVATE KEY (id)
)