-- CREATE TABLE accounts (
--     id VARCHAR(255) NOT NULL,
--     name VARCHAR(255) NOT NULL,
--     email VARCHAR(255) NOT NULL,
--     picture VARCHAR(255) NOT NULL,

--     PRIMARY KEY (id)
-- );

-- CREATE TABLE spells (
--     id INT NOT NULL AUTO_INCREMENT,
--     name VARCHAR(255) NOT NULL,
--     school VARCHAR(255) NOT NULL,
--     description VARCHAR(255) NOT NULL,
--     level INT NOT NULL,
--     castingTime INT NOT NULL,
--     material TINYINT NOT NULL,
--     verbal TINYINT NOT NULL,
--     somatic TINYINT NOT NULL,
--     concentration TINYINT NOT NULL,

--     PRIMARY KEY (id)
-- );

-- CREATE TABLE reagents (
--     id INT NOT NULL AUTO_INCREMENT,
--     spellId INT NOT NULL,
--     name VARCHAR(255) NOT NULL,
--     description VARCHAR(255) NOT NULL,

--     PRIMARY KEY (id),
--     FOREIGN KEY (spellId)
--         REFERENCES spells (id)
--         ON DELETE CASCADE

-- );

-- INSERT INTO spells
--     (name, school, description, level, castingTime, material, verbal, somatic, concentration)
-- VALUES
--     ("Animate Dead", "Necromancy", "Bring Back that Body from the Brink!", 3, 1, 1, 1, 1, 0)

-- INSERT INTO reagents
--     (spellId, name, description)
-- VALUES
--     (2, "Bat Guano", "A small ball")

-- INSERT INTO reagents
--     (spellId, name, description)
-- VALUES
--     (3, "Blood", "A drop")

-- INSERT INTO reagents
--     (spellId, name, description)
-- VALUES
--     (3, "Flesh", "A piece")

-- INSERT INTO reagents
--     (spellId, name, description)
-- VALUES
--     (3, "Bone", "A pinch")

-- DELETE FROM reagents
