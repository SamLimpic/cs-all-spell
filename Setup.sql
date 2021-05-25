CREATE TABLE accounts (
  id VARCHAR(255) NOT NULL,
  name VARCHAR(255) NOT NULL,
  email VARCHAR(255) NOT NULL,
  picture VARCHAR(255) NOT NULL,
  PRIMARY KEY (id)
);
CREATE TABLE spells (
  id INT NOT NULL AUTO_INCREMENT,
  name VARCHAR(255) NOT NULL,
  school VARCHAR(255) NOT NULL,
  description VARCHAR(255) NOT NULL,
  level INT NOT NULL,
  castingTime INT NOT NULL,
  material TINYINT NOT NULL,
  verbal TINYINT NOT NULL,
  somatic TINYINT NOT NULL,
  concentration TINYINT NOT NULL,
  PRIMARY KEY (id)
);
CREATE TABLE reagents (
  id INT NOT NULL AUTO_INCREMENT,
  name VARCHAR(255) NOT NULL,
  description VARCHAR(255) NOT NULL,
  PRIMARY KEY (id)
);
CREATE TABLE spell_reagents (
  id INT NOT NULL AUTO_INCREMENT,
  spellId INT NOT NULL,
  reagentId INT NOT NULL,
  PRIMARY KEY (id),
  FOREIGN KEY (spellId) REFERENCES spells (id) ON DELETE CASCADE,
  FOREIGN KEY (reagentId) REFERENCES reagents (id) ON DELETE CASCADE
);
INSERT INTO
  spells (
    name,
    school,
    description,
    level,
    castingTime,
    material,
    verbal,
    somatic,
    concentration
  )
VALUES
  (
    "Dream",
    "Ilusion",
    "I can show you the world...",
    5,
    1,
    1,
    1,
    1,
    0
  );
INSERT INTO
  reagents (name, description)
VALUES
  ("Writing Quill", "Plucked from a sleeping bird");
INSERT INTO
  spell_reagents (spellId, reagentId)
VALUES
  (6, 10);
SELECT
  r.*,
  s.name as spell,
  s.id as spellReagentId,
  sr.spellId,
  sr.reagentId
FROM
  spell_reagents sr
  JOIN spells s ON s.id = sr.spellId
  JOIN reagents r ON r.id = sr.reagentId
WHERE
  sr.spellId = 6